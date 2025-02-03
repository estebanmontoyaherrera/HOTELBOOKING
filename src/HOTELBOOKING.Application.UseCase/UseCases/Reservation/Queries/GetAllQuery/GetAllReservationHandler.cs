using HOTELBOOKING.Application.Dtos.Reservation;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Reservation.Queries.GetAllQuery
{
    public class GetAllReservationHandler : IRequestHandler<GetAllReservationQuery, BaseResponse<IEnumerable<GetAllReservationResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllReservationResponseDto>>> Handle(GetAllReservationQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllReservationResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todas las reservas
                var reservations = await _unitOfWork.Reservation.GetAllReservations(SP.SP_RESERVATION_LIST_ALL);

                if (reservations is not null)
                {
                    response.IsSuccess = true;
                    response.Data = reservations;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
