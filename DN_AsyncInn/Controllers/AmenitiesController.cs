using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DN_AsyncInn.Data;
using DN_AsyncInn.Models;
using DN_AsyncInn.Models.Interfaces;

namespace DN_AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenitiesManager _context;

        public AmenitiesController(IAmenitiesManager context)
        {
            _context = context;
        }

        // GET: Amenities and Search
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(await _context.SearchAmenities(searchString));
            }
            return View(await _context.GetAmenities());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var amenity = await _context.GetAmenity(id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenity)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateAmenity(amenity);
            }
            return View(amenity);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var amenity = await _context.GetAmenity(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return View(amenity);
        }
    

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenity)
        {
        if (id != amenity.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.UpdateAmenity(amenity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(amenity.ID))
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
        return View(amenity);
    }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var amenity = await _context.GetAmenity(id);
                
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenity = await _context.GetAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenitiesExists(int id)
        {
            var amenity = _context.GetAmenity(id);
            if (amenity == null)
            {
                return false;
            }
            return true;
        }
    }
}
