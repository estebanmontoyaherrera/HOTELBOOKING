using HOTELBOOKING.Application.UseCase.UseCases.Gender.Queries.GetAllQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HasPermission(Permission.ListGenders)]
        [HttpGet("ListGenders")]
        public async Task<IActionResult> ListGenders()
        {
            var response = await _mediator.Send(new GetAllGenderQuery());
            return Ok(response);
        }
    }
}
