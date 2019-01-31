﻿using DN_AsyncInn.Data;
using DN_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Services
{
    public class RoomManagementService : IRoomManager
    {
        private AsyncInnDbContext _context { get; }

        public RoomManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public void DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.ID == id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<Room> GetRoom(string name)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        /// <summary>
        /// Accepts a string and searches rooms for matching string and returns all rooms that contain that string.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Room>> SearchRooms(string searchString)
        {
            var rooms = from r in _context.Rooms
                         select r;

            rooms = rooms.Where(r => r.Name.Contains(searchString));

            return await rooms.ToListAsync();
        }

    }
}
