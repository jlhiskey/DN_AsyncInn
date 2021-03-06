﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Create Room
        Task CreateRoom(Room room);

        //Read Room
        Task<Room> GetRoom(int id);

        //Read All Rooms
        Task<IEnumerable<Room>> GetRooms();

        Task<Room> GetRoom(string name);

        //Update Room
        void UpdateRoom(Room room);

        //Delete Room
        Task DeleteRoom(Room room);

        Task DeleteRoom(int id);

        //Search Rooms
        Task<IEnumerable<Room>> SearchRooms(string searchString);
    }
}
