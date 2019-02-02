using DN_AsyncInn.Data;
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

        public async Task DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);

            var hotelRooms = await _context.HotelRooms.Where(hr => hr.RoomID == room.ID).ToListAsync();
            foreach (HotelRoom hotelRoom in hotelRooms)
            {
                _context.HotelRooms.Remove(hotelRoom);
            }
            _context.SaveChanges();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.ID == id);
            _context.Rooms.Remove(room);

            var hotelRooms = await _context.HotelRooms.Where(hr => hr.RoomID == room.ID).ToListAsync();
            foreach (HotelRoom hotelRoom in hotelRooms)
            {
                _context.HotelRooms.Remove(hotelRoom);
            }

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
            var rooms = await _context.Rooms.ToListAsync();

            foreach (Room room in rooms) // loop through and identify in  hotel room table where hotelID is equal to current hotels ID, push into Rooms
            {
                room.RoomAmenities = await _context.RoomAmenities.Where(ra => ra.RoomID == room.ID).ToListAsync();
            }
            return rooms;
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
