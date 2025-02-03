using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Dtos.Reservation
{
    public class GetAllReservationResponseDto
    {
        public int? ReservationId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? GuestCount { get; set; }
        public decimal? TotalCost { get; set; }
        public string? ReservationState { get; set; }
        public DateTime? AuditCreateDate { get; set; }
        public string? CityName { get; set; }
        public string? BookedBy { get; set; }
        public string? HotelName { get; set; }
        public string? RoomType { get; set; }

        // Datos del huésped
        public string? GuestName { get; set; }
        public DateTime? GuestBirthDate { get; set; }
        public string? Gender { get; set; }
        public string? GuestDocument { get; set; }
        public string? DocumentType { get; set; }
        public string? GuestEmail { get; set; }
        public string? GuestPhone { get; set; }

        // Contacto de emergencia
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
    }

}
