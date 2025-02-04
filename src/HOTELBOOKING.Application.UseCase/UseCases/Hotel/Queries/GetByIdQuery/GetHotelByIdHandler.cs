using AutoMapper;
using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetByIdQuery
{
    public class GetHotelByIdHandler : IRequestHandler<GetHotelByIdQuery, BaseResponse<GetHotelByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHotelByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetHotelByIdResponseDto>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetHotelByIdResponseDto>();

            try
            {
                var hotels = await _unitOfWork.Hotel.GetHotelById(request.HotelId);
                hotels.Rooms = await _unitOfWork.Hotel
                    .GetRoomsByHotelId(request.HotelId);

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetHotelByIdResponseDto>(hotels);
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
