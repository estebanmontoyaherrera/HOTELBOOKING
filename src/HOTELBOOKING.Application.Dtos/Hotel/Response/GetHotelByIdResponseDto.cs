namespace HOTELBOOKING.Application.Dtos.Hotel.Response
{
    public class GetHotelByIdResponseDto
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public decimal CommissionRate { get; set; }
        public string? StateName { get; set; }
        
        public IEnumerable<GetRoomByHotelIdResponseDto>? Rooms { get; set; }
    }

    public class GetRoomByHotelIdResponseDto
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string? Location { get; set; }
        public string? StateName { get; set; }
       
    }

}
