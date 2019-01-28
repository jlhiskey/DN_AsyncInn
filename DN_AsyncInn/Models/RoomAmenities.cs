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
        [Required]
        public int AmenitiesID { get; set; }

        [Display(Name = "Room Type")]
        [Required]
        public int RoomID { get; set; }

        //Navigation Properties

        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
