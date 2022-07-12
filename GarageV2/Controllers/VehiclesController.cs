﻿using GarageV2.Data;
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

        // GET: Vehicles
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Vehicles != null ? 
        //                  View(await _context.Vehicles.ToListAsync()) :
        //                  Problem("Entity set 'GarageDBContext.Vehicles'  is null.");
        //}




        public async Task<IActionResult> Index()
        {
            //return _context.Vehicles != null ?
            //            View(await _context.Vehicles.ToListAsync()) :
            //            Problem("Entity set 'GarageDBContext.Vehicles'  is null.");
            var viewModel = await _context.Vehicles.Select(e => new IndexViewModel
            {
                RegNr = e.RegNr.ToUpper(),
                VehicleType = e.VehicleType.ToUpper(),
                ArrivalTime = e.ArrivalTime
            }).ToListAsync();

            return View(viewModel);
        }


        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: Vehicles/Create
        public IActionResult Create()
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
            if (ModelState.IsValid)
            {
                vehicle.ArrivalTime = DateTime.Now;
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), this.ControllerContext.RouteData.Values["controller"].ToString(), new { id = vehicle.RegNr});
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
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
        public async Task<IActionResult> Edit(string id, [Bind("RegNr,Color,Wheels,Brand,Model,ArrivalTime")] Vehicle vehicle)
        {
            if (id != vehicle.RegNr)
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

    }
}
