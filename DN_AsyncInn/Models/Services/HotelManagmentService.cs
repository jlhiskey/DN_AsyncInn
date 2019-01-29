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

        public void DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(h => h.ID == id);
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
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
            return await _context.Hotels.ToListAsync();
        }
    }
}
