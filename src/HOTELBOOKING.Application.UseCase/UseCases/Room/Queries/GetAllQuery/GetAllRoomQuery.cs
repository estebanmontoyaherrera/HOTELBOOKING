using HOTELBOOKING.Application.Dtos.Room.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Room.Queries.GetAllQuery
{
    public class GetAllRoomQuery : IRequest<BaseResponse<IEnumerable<GetAllRoomResponseDto>>>
    {
    }

}
