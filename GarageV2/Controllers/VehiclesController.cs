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
            _context.Add(vehicle);
            await _context.SaveChangesAsync();
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
            if (id != vehicle.RegNr.ToUpper())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.RegNr))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.RegNr == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'GarageDBContext.Vehicles'  is null.");
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool VehicleExists(string id)
        {
            return (_context.Vehicles?.Any(e => e.RegNr == id)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<IActionResult> SetVehicleType(string vehicleType)
        {
            return Json(vehicleType);
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


        /// <summary>
        /// Gets Vehicle pure viehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Vehicle?> GetVehicleModel(string id) =>
                            await _context.Vehicles.FirstOrDefaultAsync(i =>
                                    i.RegNr.ToLower().Equals(id.ToLower()));



        public IActionResult setPopupFlag(VehicleViewModel viewModel)
        {
            throw new NotImplementedException();
        }


        private VehicleViewModel CastItem(Vehicle _vehicle)
        {
            return new VehicleViewModel
            {
                Brand = _vehicle.Brand,
                Color = _vehicle.Color,
                Model = _vehicle.Model,
                RegNr = _vehicle.RegNr,
                VehicleType = _vehicle.VehicleType,
                Wheels = _vehicle.Wheels
            };
        }


    }
}
