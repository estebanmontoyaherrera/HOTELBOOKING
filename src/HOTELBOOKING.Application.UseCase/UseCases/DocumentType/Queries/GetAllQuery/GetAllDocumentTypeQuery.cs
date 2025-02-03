using HOTELBOOKING.Application.Dtos.DocumentType;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.DocumentType.Queries.GetAllQuery
{
    public class GetAllDocumentTypeQuery : IRequest<BaseResponse<IEnumerable<GetAllDocumentTypeResponseDto>>>
    {
    }
}
