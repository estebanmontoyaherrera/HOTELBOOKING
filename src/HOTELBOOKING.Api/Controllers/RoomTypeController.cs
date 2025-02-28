﻿using HOTELBOOKING.Application.UseCase.UseCases.RoomType.GetAllQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOTELBOOKING.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HasPermission(Permission.ListRoomTypes)]
        [HttpGet("ListRoomTypes")]
        public async Task<IActionResult> ListRoomTypes()
        {
            var response = await _mediator.Send(new GetAllRoomTypeQuery());
            return Ok(response);
        }
    }
}
