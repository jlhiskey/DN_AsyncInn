using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models
{
    public class HotelRoom
    {
        
        [Display(Name = "Hotel")]
        public int HotelID { get; set; }
        [Required]
        public int RoomNumber { get; set; }

        
        [Display(Name = "Room")]
        public decimal RoomID { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        //Navigation Properties

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}
