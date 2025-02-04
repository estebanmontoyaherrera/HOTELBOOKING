using HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Reservation.Queries.GetAllQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Asignamos el permiso adecuado
        [HasPermission(Permission.ListReservations)]
        [HttpGet("ListReservations")]
        public async Task<IActionResult> ListReservations()
        {
            var response = await _mediator.Send(new GetAllReservationQuery());
            return Ok(response);
        }

        // Asignamos el permiso adecuado
        [HasPermission(Permission.CreateReservation)]
        [HttpPost("Create")]
        public async Task<IActionResult> RegisterReservation([FromBody] CreateReservationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
