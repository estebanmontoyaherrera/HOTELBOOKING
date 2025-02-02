using HOTELBOOKING.Application.UseCase.UseCases.RoomType.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListRoomTypes")]
        public async Task<IActionResult> ListRoomTypes()
        {
            var response = await _mediator.Send(new GetAllRoomTypeQuery());
            return Ok(response);
        }

    }
}
