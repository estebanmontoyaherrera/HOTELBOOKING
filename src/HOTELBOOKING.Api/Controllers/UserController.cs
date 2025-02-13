using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.DeleteCommand;
using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.UpdateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.User.Queries.GetAllQuery;
using HOTELBOOKING.Application.UseCase.UseCases.User.Queries.LoginQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HasPermission(Permission.ListUsers)]
        [HttpGet("ListUsers")]
        public async Task<IActionResult> ListUsers()
        {
            var response = await _mediator.Send(new GetAllUserQuery());
            return Ok(response);
        }

        
        [HasPermission(Permission.CreateUsers)]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUsers([FromBody] List<CreateUserCommand> commands)
        {
            if (commands == null || !commands.Any())
            {
                return BadRequest("Debe proporcionar al menos un usuario para crear.");
            }

            var responses = new List<object>();

            foreach (var command in commands)
            {
                var response = await _mediator.Send(command);
                responses.Add(response);
            }

            return Ok(responses);
        }

        
        [HasPermission(Permission.UpdateUser)]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HasPermission(Permission.ChangeStateUser)]
        [HttpPatch("ChangeState")]
        public async Task<IActionResult> ChangeStateUser([FromBody] ChangeStateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        
        [HasPermission(Permission.DeleteUser)]
        [HttpDelete("Delete/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _mediator.Send(new DeleteUserCommand() { UserId = userId });
            return Ok(response);
        }
    }
}
