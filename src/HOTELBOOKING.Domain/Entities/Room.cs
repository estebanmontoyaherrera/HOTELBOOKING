namespace HOTELBOOKING.Domain.Entities
{
    public class Room
    {
        public int? RoomId { get; set; }
        public int? HotelId { get; set; }       
        public int? RoomTypeId { get; set; }
        public int? Capacity { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal? Taxes { get; set; }
        public string? Location { get; set; }
        public int? State { get; set; }
        public string? StateName { get; set; }
        public string? RoomStateName { get; set; }
        public DateTime? AuditCreateDate { get; set; } 
        

       
    }

}
