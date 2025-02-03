using MediatR;
using Microsoft.AspNetCore.Mvc;
using HOTELBOOKING.Application.UseCase.UseCases.DocumentType.Queries.GetAllQuery;
namespace HOTELBOOKING.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HasPermission(Permission.ListDocumentTypes)]
        [HttpGet("ListDocumentTypes")]
        public async Task<IActionResult> ListDocumentTypes()
        {
            var response = await _mediator.Send(new GetAllDocumentTypeQuery());
            return Ok(response);
        }
    }
}
