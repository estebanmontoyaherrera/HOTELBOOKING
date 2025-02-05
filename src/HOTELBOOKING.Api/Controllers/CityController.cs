using HOTELBOOKING.Application.UseCase.UseCases.City.GetAllQuery;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetHotelsRoomsByCityId;
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

        [HttpGet("{cityId:int}/{checkIn:datetime}/{checkOut:datetime}/{capacity:int}")]
        public async Task<IActionResult> GetHotelsRoomsByCityId(int cityId, DateTime checkIn, DateTime checkOut, int capacity)
        {
            var response = await _mediator.Send(new GetHotelsRoomsByCityIdQuery()
            {
                CityId = cityId,
                CheckIn = checkIn,
                CheckOut = checkOut,
                Capacity = capacity
            });

            return Ok(response);
        }

    }
}
