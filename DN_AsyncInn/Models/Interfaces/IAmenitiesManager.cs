using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create amenity
        Task CreateAmenity(Amenities amenity);

        //Read amenity
        Task<Amenities> GetAmenity(int id);

        //Read All Amenities
        Task<IEnumerable<Amenities>> GetAmenities();

        Task<Amenities> GetAmenity(string name);

        //Update amenity
        void UpdateAmenity(Amenities amenity);

        //Delete amenity
        void DeleteAmenity(Amenities amenity);

        void DeleteAmenity(int id);
    }
}
