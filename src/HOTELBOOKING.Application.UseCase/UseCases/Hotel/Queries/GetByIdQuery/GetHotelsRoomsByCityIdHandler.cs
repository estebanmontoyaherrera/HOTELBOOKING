using AutoMapper;
using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetHotelsRoomsByCityId
{
    public class GetHotelsRoomsByCityIdHandler : IRequestHandler<GetHotelsRoomsByCityIdQuery, BaseResponse<IEnumerable<GetHotelsRoomsByCityIdResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHotelsRoomsByCityIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetHotelsRoomsByCityIdResponseDto>>> Handle(GetHotelsRoomsByCityIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetHotelsRoomsByCityIdResponseDto>>();

            try
            {
                var hotels = await _unitOfWork.Hotel.GetHotelsRoomsByCityId(request.CityId, request.CheckIn, request.CheckOut, request.Capacity);

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<GetHotelsRoomsByCityIdResponseDto>>(hotels);
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
