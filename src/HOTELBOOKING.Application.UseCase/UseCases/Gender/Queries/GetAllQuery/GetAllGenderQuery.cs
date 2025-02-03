using HOTELBOOKING.Application.Dtos.Gender;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Gender.Queries.GetAllQuery
{
    public class GetAllGenderQuery : IRequest<BaseResponse<IEnumerable<GetAllGenderResponseDto>>>
    {
    }

}
