using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.DeleteCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.UpdateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetAllQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HasPermission(Permission.ListHotels)]
        [HttpGet("ListHotels")]
        public async Task<IActionResult> ListHotels()
        {
            var response = await _mediator.Send(new GetAllHotelQuery());
            return Ok(response);
        }
        //[HasPermission(Permission.CreateHotel)]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateHotel([FromBody] UpdateHotelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateHotel([FromBody] ChangeStateHotelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{hotelId:int}")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            var response = await _mediator.Send(new DeleteHotelCommand() { HotelId = hotelId });
            return Ok(response);
        }

    }
}
