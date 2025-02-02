using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.UpdateCommand
{
    public class UpdateHotelCommand : IRequest<BaseResponse<bool>>
    {
        public int? HotelId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public string? CommissionRate { get; set; }
    }
}
