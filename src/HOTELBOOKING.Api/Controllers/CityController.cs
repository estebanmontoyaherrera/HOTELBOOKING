using HOTELBOOKING.Application.UseCase.UseCases.City.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListCities")]
        public async Task<IActionResult> ListCity()
        {
            var response = await _mediator.Send(new GetAllCityQuery());
            return Ok(response);
        }
    }
}
