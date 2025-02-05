namespace HOTELBOOKING.Domain.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public decimal? CommissionRate { get; set; }
        public int? State { get; set; }
        public string? StateName { get; set; }
        public DateTime? AuditCreateDate { get; set; }

        public IEnumerable<Room> Rooms { get; set; } = null!;
    }

}
