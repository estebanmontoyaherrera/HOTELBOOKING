using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Dtos.City.Response
{
    public class GetAllCityResponseDto
    {
        public int? CityId { get; set; }
        public string? Name { get; set; }
    }
}
