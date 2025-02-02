using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.ChangeStateCommand
{
    public class ChangeStateHotelCommand : IRequest<BaseResponse<bool>>
    {
        public int HotelId { get; set; }
        public int State { get; set; }
    }
}
