using CarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator mediator;
        public TagCloudsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var data = await mediator.Send(new GetTagCloudQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var data = await mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(RemoveTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud Deleted");
        }
    }
}
