using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int GuestCount { get; set; }
        public int CityId { get; set; }
        public decimal TotalCost { get; set; }
        public int State { get; set; } = 1;
        public DateTime AuditCreateDate { get; set; } = DateTime.UtcNow;

      
    }

}
