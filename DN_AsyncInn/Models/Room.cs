using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models
{
    public enum Layout { Studio, OneBedroom, TwoBedroom }

    public class Room
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
