using HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetAllQuery;
using HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListRoles")]
        public async Task<IActionResult> ListRole()
        {
            var response = await _mediator.Send(new GetAllRoleQuery());
            return Ok(response);
        }

        [HttpGet("{roleId:int}")]
        public async Task<IActionResult> RoleById(int roleId)
        {
            var response = await _mediator.Send(new GetRoleByIdQuery() { RoleId = roleId });
            return Ok(response);
        }

     
    }
}
