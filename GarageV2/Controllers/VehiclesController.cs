using GarageV2.Data;
using GarageV2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageV2.Controllers
{

    public class VehiclesController : Controller
    {
        private readonly GarageDBContext _context;

        public VehiclesController(GarageDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await GetVehicles().ConfigureAwait(false);
            return View(viewModel);
        }


        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }



            var vehicle = await GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegNr,Color,Wheels,Brand,Model,VehicleType")] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                ViewData["HeadLine"] = "Meddelande";
                ViewData["UserMessage"] = $"Välj fordonstyp i formuläret";
                return View();
            }


            var isExist = await GetVehicle(vehicle.RegNr);
            if (isExist is not null)
            {
                ViewData["HeadLine"] = "Meddelande";
                ViewData["UserMessage"] = $"Angivet registeringsnummer {vehicle.RegNr} existerar redan vilket måste vara unikt";
                return View();
            }

            vehicle.ArrivalTime = DateTime.Now;
            vehicle.RegNr = vehicle.RegNr.ToUpper();
            _context.Add(vehicle);
            await SaveChangesAsync();
            return RedirectToAction(nameof(Details), this.ControllerContext.RouteData.Values["controller"].ToString(), new { id = vehicle.RegNr });


        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vehicles == null)
            {
                ViewData["UserMessage"] = $"Regnummer {id} saknas";

                return NotFound();
            }

            var vehicle = await GetVehicleModel(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RegNr,Color,Wheels,Brand,Model,ArrivalTime,VehicleType")] Vehicle vehicle)
        {


            if (!ModelState.IsValid)
            {
                ViewData["UserMessage"] = $"Någonting gick fel. kontrollera att obligatoriska värden är ifyllda";
                return View();
            }


            if (vehicle.VehicleType.Contains("välj", StringComparison.OrdinalIgnoreCase))
            {
                ViewData["UserMessage"] = "Välj ett fordon i listan";
                return View();
            }


            if (id != vehicle.RegNr.ToUpper())
            {
                ViewData["UserMessage"] = $"Registeringsnummer {id} saknas";
                return View();
            }

            _context.Update(vehicle);
            await SaveChangesAsync();


            return RedirectToAction(nameof(Index));

            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }


            var vehicle = await GetVehicleModel(id);
            if (vehicle == null) { return NotFound(); }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            TicketViewModel Kvitto = new();
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'GarageDBContext.Vehicles'  is null.");
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {



                Kvitto.ArrivalTime = vehicle.ArrivalTime;
                Kvitto.CheckOutTime = DateTime.Now;
                Kvitto.RegNr = vehicle.RegNr;

                Kvitto.Ptime = DateTime.Now - vehicle.ArrivalTime;
                Kvitto.Price = (float)Kvitto.Ptime.TotalHours * 12;
                Kvitto.Price = (float)Math.Round(Kvitto.Price, 2);
                if (Kvitto.Price < 12) Kvitto.Price = 12;
                // avgift = 12Kr/h

                _context.Vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DeleteSucess), Kvitto);
        }


        public async Task<IActionResult> DeleteSucess(TicketViewModel kvitto)
        {


            return View(kvitto);
        }

        public async Task<IActionResult> IndexFilter(string RegNr)
        {
            var vehicles = string.IsNullOrWhiteSpace(RegNr) ?
                                    _context.Vehicles :
                                    _context.Vehicles.Where(m => m.RegNr.ToLower()!.StartsWith(RegNr.ToLower()));

            var model = await vehicles.Select(e => new VehicleViewModel
            {
                RegNr = e.RegNr.ToUpper(),
                VehicleType = e.VehicleType.ToUpper(),
                ArrivalTime = e.ArrivalTime
            }).ToListAsync();

            return View(nameof(Index), model);


        }

        // Changes


        private bool VehicleExists(string id)
        {
            return (_context.Vehicles?.Any(e => e.RegNr == id)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<IActionResult> SetVehicleType(string vehicleType)
        {
            return Json(vehicleType);
        }

        [HttpPost]
        public async Task<IActionResult> Receit
            (
           TicketViewModel model
            )
        {
            ReceitViewModel Receit = new()
            {
                Reg = model.RegNr,
                Arrival = model.ArrivalTime,
                CheckOut = model.CheckOutTime,
                ParkTime = model.Ptime,
                ParkingPrice = model.Price
            };

            return View(Receit);
        }


        /// <summary>
        /// Gets Vehicle pure viehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Vehicle?> GetVehicleModel(string id) =>
                            await _context.Vehicles.FirstOrDefaultAsync(i =>
                                    i.RegNr.ToLower().Equals(id.ToLower()));


        /// <summary>
        /// Save DB changes
        /// </summary>
        /// <returns></returns>
        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        private async Task<VehicleViewModel> GetVehicle(string id)
        {
            var result = await _context!.Vehicles!.FirstOrDefaultAsync(i =>
                i.RegNr.ToLower().Equals(id.ToLower()));
            if (result == null)
            {
                return null;
            }

            return new VehicleViewModel
            {
                ArrivalTime = result.ArrivalTime,
                RegNr = result.RegNr,
                VehicleType = result.VehicleType,
                Model = result.Model,
                Brand = result.Brand,
                Color = result.Color,
                Wheels = result.Wheels

            };
        }

        private async Task<IEnumerable<VehicleViewModel>> GetVehicles()
        {
            return await _context.Vehicles.Select(e => new VehicleViewModel
            {
                RegNr = e.RegNr.ToUpper(),
                VehicleType = e.VehicleType.ToUpper(),
                ArrivalTime = e.ArrivalTime,
            }).ToListAsync();
        }
    }
}
