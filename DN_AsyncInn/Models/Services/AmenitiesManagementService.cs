using DN_AsyncInn.Data;
using DN_AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Services
{
    public class AmenitiesManagementService : IAmenitiesManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenitiesManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenity(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(string name)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.Name == name);
        }

        public void UpdateAmenity(Amenities amenity)
        {
            _context.Amenities.Update(amenity);
            _context.SaveChanges();
        }

        public void DeleteAmenity(Amenities amenity)
        {
            _context.Amenities.Remove(amenity);
            _context.SaveChanges();
        }

        public void DeleteAmenity(int id)
        {
            Amenities amenity = _context.Amenities.FirstOrDefault(a => a.ID == id);
            _context.Amenities.Remove(amenity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Amenities>> SearchAmenities(string searchString)
        {
            var amenities = from a in _context.Amenities
                         select a;

            amenities = amenities.Where(a => a.Name.Contains(searchString));

            return await amenities.ToListAsync();
        }
    }
}
