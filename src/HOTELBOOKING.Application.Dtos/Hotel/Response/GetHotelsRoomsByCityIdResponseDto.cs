namespace HOTELBOOKING.Application.Dtos.Hotel.Response
{
    public class GetHotelsRoomsByCityIdResponseDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public decimal? CommissionRate { get; set; }
        public string? StateName { get; set; }
       
        public IEnumerable<GetHotelRoomResponseDto> Rooms { get; set; } = Enumerable.Empty<GetHotelRoomResponseDto>();
    }

    public class GetHotelRoomResponseDto
    {
        public int RoomId { get; set; }
        //public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string? Location { get; set; } 
        public string? RoomStateName { get; set; } 
       
    }
}
