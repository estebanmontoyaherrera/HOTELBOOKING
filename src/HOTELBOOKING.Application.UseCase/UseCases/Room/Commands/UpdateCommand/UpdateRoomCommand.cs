using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.UpdateCommand
{
    public class UpdateRoomCommand : IRequest<BaseResponse<bool>>
    {
        public int? RoomId { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public int? Capacity { get; set; }
        public string? BaseCost { get; set; }
        public string? Taxes { get; set; }
        public string? Location { get; set; }
    }
}
