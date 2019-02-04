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
        [Required(ErrorMessage = "Please Select a hotel")]
        public int HotelID { get; set; }

        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Please Select a Room Number")]
        public int RoomNumber { get; set; }

        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Please Select a Room Type")]
        public decimal RoomID { get; set; }

        [Required(ErrorMessage = "Please Select a Rate For This Room")]
        [Range(1.00, 10000.00)]
        public decimal Rate { get; set; }

        [Display(Name = "Is The Room Pet Friendly?")]
        public bool PetFriendly { get; set; }

        //Navigation Properties

        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}
