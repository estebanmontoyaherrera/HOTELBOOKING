using HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Reservation.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HasPermission(Permission.ListReservations)] 
        [HttpGet("ListReservations")]
        public async Task<IActionResult> ListReservations()
        {
            var response = await _mediator.Send(new GetAllReservationQuery());
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> RegisterReservation([FromBody] CreateReservationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
