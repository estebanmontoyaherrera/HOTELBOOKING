using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetAllQuery
{
    public class GetAllRoleQuery : IRequest<BaseResponse<IEnumerable<GetAllRoleResponseDto>>>
    {
    }
}
