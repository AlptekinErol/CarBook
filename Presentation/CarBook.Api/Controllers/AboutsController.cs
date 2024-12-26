using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator mediator;
        public AboutsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var data = await mediator.Send(new GetAboutQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var data = await mediator.Send(new GetAboutByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await mediator.Send(command);
            return Ok("About Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await mediator.Send(command);
            return Ok("About Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAbout(RemoveAboutCommand command)
        {
            await mediator.Send(command);
            return Ok("About Deleted");
        }
    }
}
