using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Dtos.RoomType.Response
{
    public class GetAllRoomTypeResponseDto
    {
        public int? RoomTypeId { get; set; }
        public string? Name { get; set; }
    }
}
