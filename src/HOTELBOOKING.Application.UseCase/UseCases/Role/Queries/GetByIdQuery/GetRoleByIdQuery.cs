using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetByIdQuery
{
    public class GetRoleByIdQuery : IRequest<BaseResponse<GetRoleByIdResponseDto>>
    {
        public int RoleId { get; set; }
    }
}
