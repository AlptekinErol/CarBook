using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var data = await mediator.Send(new GetAuthorQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var data = await mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await mediator.Send(command);
            return Ok("Author Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await mediator.Send(command);
            return Ok("Author Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Author Deleted");
        }
    }
}
