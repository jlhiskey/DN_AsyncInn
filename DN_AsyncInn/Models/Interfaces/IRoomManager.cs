using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models.Interfaces
{
    interface IRoomManager
    {
        //Create Room
        Task CreateRoom(Room room);

        //Read Room
        Task<Hotel> GetRoom(int id);

        //Read All Rooms
        Task<IEnumerable<Room>> GetRooms();

        Task<Hotel> GetRoom(string Name);

        //Update Room
        void UpdateRoom(Room room);

        //Delete Room
        void DeleteRoom(Room room);

        void DeleteRoom(int id);
    }
}
