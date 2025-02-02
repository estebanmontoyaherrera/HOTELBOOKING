using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetAllQuery
{
    public class GetAllHotelHandler : IRequestHandler<GetAllHotelQuery, BaseResponse<IEnumerable<GetAllHotelResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllHotelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllHotelResponseDto>>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllHotelResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todos los hoteles
                var hotels = await _unitOfWork.Hotel.GetAllHotels(SP.SP_HOTEL_LIST);

                if (hotels is not null)
                {
                    response.IsSuccess = true;
                    response.Data = hotels;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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
