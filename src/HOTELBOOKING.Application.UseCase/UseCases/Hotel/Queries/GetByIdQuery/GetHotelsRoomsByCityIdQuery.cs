using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetHotelsRoomsByCityId
{
    public class GetHotelsRoomsByCityIdQuery : IRequest<BaseResponse<IEnumerable<GetHotelsRoomsByCityIdResponseDto>>>
    {
        public int CityId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Capacity { get; set; }
    }
}
