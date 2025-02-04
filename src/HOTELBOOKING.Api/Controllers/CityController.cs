using HOTELBOOKING.Application.UseCase.UseCases.City.GetAllQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        //[HasPermission(Permission.ListCities)]
        [HttpGet("ListCities")]
        public async Task<IActionResult> ListCities()
        {
            var response = await _mediator.Send(new GetAllCityQuery());
            return Ok(response);
        }
    }
}
