using HOTELBOOKING.Application.Dtos.User.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.User.Queries.GetAllQuery
{
    public class GetAllUserQuery : IRequest<BaseResponse<IEnumerable<GetAllUserResponseDto>>>
    {

    }
}
