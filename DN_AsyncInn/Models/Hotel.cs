using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
