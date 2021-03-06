﻿using System;
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
    public class HotelController : Controller
    {
        private readonly IHotelManager _context;

        public HotelController(IHotelManager context)
        {
            _context = context;
        }

        // GET: Hotel and Search
        public async Task<IActionResult> Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(await _context.SearchHotels(searchString));
            }
            return View(await _context.GetHotels());
        }

        // GET: Hotel/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }


            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(hotel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     _context.UpdateHotel(hotel);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.GetHotel(id);
            _context.DeleteHotel(hotel);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            var hotel = _context.GetHotel(id);
            if (hotel == null)
            {
                return false;
            }
            return true;
        }

        
    }
}
