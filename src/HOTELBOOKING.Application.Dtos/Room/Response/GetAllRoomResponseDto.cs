using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Dtos.Room.Response
{
    public class GetAllRoomResponseDto
    {
        public int? RoomId { get; set; }
        public int? HotelId { get; set; }
        public string? HotelName { get; set; }
        public int? RoomTypeId { get; set; }
        public string? RoomTypeName { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal? Taxes { get; set; }
        public string? Location { get; set; }
        public string? StateName { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
