using HOTELBOOKING.Application.Dtos.City.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.City.GetAllQuery
{
    public class GetAllCityQuery : IRequest<BaseResponse<IEnumerable<GetAllCityResponseDto>>>
    {
    }
}
