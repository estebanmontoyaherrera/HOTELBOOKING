using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Domain.Entities
{
    public class UserHotel
    {
        public int? UserId { get; set; }  
        public int? HotelId { get; set; } 
        public bool? IsPreferred { get; set; } 


    }

}
