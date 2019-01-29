using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Interfaces
{
     public interface IHotelManager
    {
        //Create Hotel
        Task CreateHotel(Hotel hotel);

        //Read Hotel
        Task<Hotel> GetHotel(int id);

        //Read All Hotels
        Task<IEnumerable<Hotel>> GetHotels();

        Task<Hotel> GetHotel(string name);

        //Update Hotel
        void UpdateHotel(Hotel hotel);

        //DeleteHotel
        void DeleteHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}
