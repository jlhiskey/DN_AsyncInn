using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create Amenities
        Task CreateAmenity(Amenities amenity);

        //Read Amenity
        Task<Room> GetAmenity(int id);

        //Read All Rooms
        Task<IEnumerable<Amenities>> GetRooms();

        Task<Amenities> GetAmenities(string name);

        //Update Amenity
        void UpdateAmenity(Amenities amenity);

        //Delete Amenity
        void DeleteAmenity(Amenities amenity);

        void DeleteAmenity(int id);
    }
}
