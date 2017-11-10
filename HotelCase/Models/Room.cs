using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCase.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public RoomSize Size { get; set; }
        public IList<Booking> Bookings { get; set; }
    }

    public enum RoomType
    {
        Luxury,
        Business,
        Normal,
        Buget
    }

    public enum RoomSize
    { 
        [Display(Name = "1 person")]
        Single,
        [Display(Name = "2-3 persons")]
        TwotoThree,
        [Display(Name = "4-5 persons")]
        FourtoFive,
        [Display(Name = "6 persons")]
        SixPersons
    }
}
