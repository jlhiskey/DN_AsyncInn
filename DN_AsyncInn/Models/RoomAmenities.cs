using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models
{
    public class RoomAmenities
    {
        [Display(Name = "Amenity")]
        public int AmenitiesID { get; set; }

        [Display(Name = "Room Type")]
        public int RoomID { get; set; }

        //Navigation Properties

        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
