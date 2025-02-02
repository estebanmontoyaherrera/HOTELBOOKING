using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.DeleteCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.UpdateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListHotels")]
        public async Task<IActionResult> ListHotel()
        {
            var response = await _mediator.Send(new GetAllHotelQuery());
            return Ok(response);
        }

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
