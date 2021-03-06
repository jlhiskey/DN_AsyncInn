﻿using System;
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

        //Read All HotelRooms
        Task<IEnumerable<HotelRoom>> GetHotelRooms(int hotelID);

        //Update Hotel
        void UpdateHotel(Hotel hotel);

        //DeleteHotel
        void DeleteHotel(Hotel hotel);

        Task DeleteHotel(int id);

        //Search Hotels
        Task<IEnumerable<Hotel>> SearchHotels(string searchString);

    }
}
