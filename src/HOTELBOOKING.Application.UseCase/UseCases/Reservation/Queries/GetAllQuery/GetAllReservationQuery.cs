using HOTELBOOKING.Application.Dtos.Reservation;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Reservation.Queries.GetAllQuery
{
    public class GetAllReservationQuery : IRequest<BaseResponse<IEnumerable<GetAllReservationResponseDto>>>
    {
    }

}
