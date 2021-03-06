﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models
{
    

    public class Room
    {
        
        public int ID { get; set; }

        [Display(Name = "Room Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRooms { get; set; }

        [Display(Name = "Total Room Amenities")]
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio = 0,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom
    }
}
