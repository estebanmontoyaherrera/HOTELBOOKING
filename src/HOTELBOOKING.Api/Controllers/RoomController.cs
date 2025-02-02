using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.DeleteCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.UpdateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Queries.GetAllQuery;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListRooms")]
        public async Task<IActionResult> ListRoom()
        {
            var response = await _mediator.Send(new GetAllRoomQuery());
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRoom([FromBody] UpdateRoomCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateRoom([FromBody] ChangeStateRoomCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{roomId:int}")]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            var response = await _mediator.Send(new DeleteRoomCommand() { RoomId = roomId });
            return Ok(response);
        }
    }
}
