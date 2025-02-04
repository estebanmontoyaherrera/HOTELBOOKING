using HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetAllQuery;
using HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetByIdQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HasPermission(Permission.ListRoles)]
        [HttpGet("ListRoles")]
        public async Task<IActionResult> ListRole()
        {
            var response = await _mediator.Send(new GetAllRoleQuery());
            return Ok(response);
        }

        
        [HasPermission(Permission.GetRoleById)]
        [HttpGet("{roleId:int}")]
        public async Task<IActionResult> RoleById(int roleId)
        {
            var response = await _mediator.Send(new GetRoleByIdQuery() { RoleId = roleId });
            return Ok(response);
        }
    }
}
