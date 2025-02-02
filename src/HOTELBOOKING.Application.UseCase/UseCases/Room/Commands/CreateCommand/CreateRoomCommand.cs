using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.CreateCommand
{
    public class CreateRoomCommand : IRequest<BaseResponse<bool>>
    {
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public string? BaseCost { get; set; }
        public string? Taxes { get; set; }
        public string? Location { get; set; }
      
    }
}
