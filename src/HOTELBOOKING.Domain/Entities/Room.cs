using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Domain.Entities
{
    public class Room
    {
        public int? RoomId { get; set; }
        public int? HotelId { get; set; }       
        public int? RoomTypeId { get; set; }       
        public decimal? BaseCost { get; set; }
        public decimal? Taxes { get; set; }
        public string? Location { get; set; }
        public int? State { get; set; }
        
        public DateTime? AuditCreateDate { get; set; } 
        

       
    }

}
