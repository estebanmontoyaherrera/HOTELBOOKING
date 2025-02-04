using MediatR;
using Microsoft.AspNetCore.Mvc;
using HOTELBOOKING.Application.UseCase.UseCases.DocumentType.Queries.GetAllQuery;
using HOTELBOOKING.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace HOTELBOOKING.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        ////[HasPermission(Permission.ListDocumentTypes)]
        [HttpGet("ListDocumentTypes")]
        public async Task<IActionResult> ListDocumentTypes()
        {
            var response = await _mediator.Send(new GetAllDocumentTypeQuery());
            return Ok(response);
        }
    }
}
