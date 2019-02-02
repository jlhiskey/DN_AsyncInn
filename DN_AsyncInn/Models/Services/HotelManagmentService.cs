using DN_AsyncInn.Data;
using DN_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Services
{
    public class HotelManagmentService : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        // Connects to DB
        public HotelManagmentService(AsyncInnDbContext context)
        {
            _context = context;
           
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }
            
        public void DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(ho => ho.ID == id);
            _context.Hotels.Remove(hotel);

            var hotelRooms = await _context.HotelRooms.Where(hr => hr.HotelID == hotel.ID).ToListAsync();
            foreach (HotelRoom hotelRoom in hotelRooms)
            {
                _context.HotelRooms.Remove(hotelRoom);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            
            return await _context.Hotels.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<Hotel> GetHotel(string name)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.Name == name);
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync(); // initial call out to grab hotels

            foreach (Hotel hotel in hotels) // loop through and identify in  hotel room table where hotelID is equal to current hotels ID, push into Rooms
            {
                hotel.HotelRooms = await _context.HotelRooms.Where(ro => ro.HotelID == hotel.ID).ToListAsync();
            }
            return hotels;
        }

        /// <summary>
        /// Accepts a string and searches hotels for matching string and returns all hotels that contain that string.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Hotel>> SearchHotels(string searchString)
        {
            var hotels = from h in _context.Hotels
                         select h;
            
            hotels = hotels.Where(h => h.Name.Contains(searchString));
            
            return await hotels.ToListAsync();
        }


        
    }
}
