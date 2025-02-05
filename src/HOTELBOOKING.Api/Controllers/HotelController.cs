using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.DeleteCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.UpdateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetAllQuery;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetByIdQuery;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.CreateCommand;
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

        
        [HasPermission(Permission.ListHotels)]
        [HttpGet("ListHotels")]
        public async Task<IActionResult> ListHotels()
        {
            var response = await _mediator.Send(new GetAllHotelQuery());
            return Ok(response);
        }

        
        [HasPermission(Permission.GetHotelById)]
        [HttpGet("{hotelId:int}")]
        public async Task<IActionResult> TakeExamById(int hotelId)
        {
            var response = await _mediator
                .Send(new GetHotelByIdQuery() { HotelId = hotelId });
            return Ok(response);
        }

        [HttpPost("CreateHotelRooms")]
        public async Task<IActionResult> CreateHotelRooms([FromBody] CreateHotelRoomCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.CreateHotel)]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        
        [HasPermission(Permission.AssignRoom)]
        [HttpPost("AssignRoom")]
        public async Task<IActionResult> AssignRoom([FromBody] CreateRoomCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        
        [HasPermission(Permission.UpdateHotel)]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateHotel([FromBody] UpdateHotelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

       
        [HasPermission(Permission.ChangeStateHotel)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateHotel([FromBody] ChangeStateHotelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        
        [HasPermission(Permission.DeleteHotel)]
        [HttpDelete("Delete/{hotelId:int}")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            var response = await _mediator.Send(new DeleteHotelCommand() { HotelId = hotelId });
            return Ok(response);
        }
    }
}
