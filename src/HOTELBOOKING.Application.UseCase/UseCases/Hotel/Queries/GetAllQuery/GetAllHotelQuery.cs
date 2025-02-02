using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetAllQuery
{
    public class GetAllHotelQuery : IRequest<BaseResponse<IEnumerable<GetAllHotelResponseDto>>>
    {
    }

}
