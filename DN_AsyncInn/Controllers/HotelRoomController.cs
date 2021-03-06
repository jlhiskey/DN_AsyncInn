﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DN_AsyncInn.Data;
using DN_AsyncInn.Models;


namespace DN_AsyncInn.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRoom
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        

        // GET: HotelRoom/Details/5
        public async Task<IActionResult> Details(int hotelID, decimal roomID, int roomNumber)
        {
            if (hotelID == 0 || roomID == 0)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(m => m.HotelID == hotelID && m.RoomID == roomID && m.RoomNumber == roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRoom/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            var existingRoom = _context.HotelRooms.FirstOrDefault(m => m.HotelID == hotelRoom.HotelID && m.RoomNumber == hotelRoom.RoomNumber);

            if (existingRoom == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(hotelRoom);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
                ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
                return View(hotelRoom);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: HotelRoom/Edit/5
        
        public async Task<IActionResult> Edit(int hotelID, decimal roomID, int roomNumber)
        {
            if (hotelID == 0 || roomID == 0)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(m => m.HotelID == hotelID && m.RoomID == roomID && m.RoomNumber == roomNumber);
            
            if (hotelRoom == null)
            {
                return NotFound();
            }
            
            return View(hotelRoom);
        }

        // POST: HotelRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hotelID, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
                ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
                return RedirectToAction(nameof(Index));
            }
            
            return View(hotelRoom);
        }

        // GET: HotelRoom/Delete/5
        public async Task<IActionResult> Delete(int hotelID, decimal roomID, int roomNumber)
        {
            if (hotelID == 0 || roomID == 0)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(m => m.HotelID == hotelID && m.RoomID == roomID && m.RoomNumber == roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(HotelRoom hotelRoom)
        {
            
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
