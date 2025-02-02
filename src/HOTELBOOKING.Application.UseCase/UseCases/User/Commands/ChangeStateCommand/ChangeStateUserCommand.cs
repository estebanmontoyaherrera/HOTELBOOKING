using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.User.Commands.ChangeStateCommand
{
    public class ChangeStateUserCommand : IRequest<BaseResponse<bool>>
    {
        public int UserId { get; set; }
        public int State { get; set; }
    }
}
