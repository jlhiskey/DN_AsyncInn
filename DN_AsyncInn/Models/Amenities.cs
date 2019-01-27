﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Navigation Properties

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
