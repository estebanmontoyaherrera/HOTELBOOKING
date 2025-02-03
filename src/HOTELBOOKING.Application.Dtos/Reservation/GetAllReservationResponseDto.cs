using System;

namespace HOTELBOOKING.Application.Dtos.Reservation
{
    public class GetAllReservationResponseDto
    {
        public int? ReservationId { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }
        public decimal? TotalCost { get; set; }
        public string? ReservationState { get; set; }
        public DateTime? AuditCreateDate { get; set; }
        public string? BookedBy { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? CityName { get; set; }
        public string? RoomType { get; set; }
        public int RoomCapacity { get; set; } // Capacidad de la habitación

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

        // Costo total por noche
        public decimal? TotalCostPerNight { get; set; }
    }
}