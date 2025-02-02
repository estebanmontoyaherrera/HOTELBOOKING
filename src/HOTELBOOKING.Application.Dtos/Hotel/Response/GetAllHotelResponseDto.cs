using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Dtos.Hotel.Response
{
    public class GetAllHotelResponseDto
    {
        public int? HotelId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }
        public decimal? CommissionRate { get; set; }
        public string? StateName { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
