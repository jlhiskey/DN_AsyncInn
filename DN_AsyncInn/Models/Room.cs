using System;
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
        public string Name { get; set; }

        [Required(ErrorMessage = "Layout Must Be Selected")]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRooms { get; set; }
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
