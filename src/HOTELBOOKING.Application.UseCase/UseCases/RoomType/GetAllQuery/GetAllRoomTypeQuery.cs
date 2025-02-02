using HOTELBOOKING.Application.Dtos.RoomType.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.RoomType.GetAllQuery
{
    public class GetAllRoomTypeQuery : IRequest<BaseResponse<IEnumerable<GetAllRoomTypeResponseDto>>>
    {
    }
}
