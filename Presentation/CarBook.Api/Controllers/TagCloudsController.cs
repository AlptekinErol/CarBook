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

        /// <summary>
        /// Tüm TagCloud'ları getirir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var data = await mediator.Send(new GetTagCloudQuery());
            return Ok(data);
        }

        /// <summary>
        /// Belirli bir TagCloud'u ID ile getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var data = await mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(data);
        }

        /// <summary>
        /// Belirli bir Blog ID'ye ait TagCloud'u getirir.
        /// </summary>
        [HttpGet("blog/{blogId}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int blogId)
        {
            var data = await mediator.Send(new GetTagCloudByBlogIdQuery(blogId));
            return Ok(data);
        }

        /// <summary>
        /// Yeni bir TagCloud oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud Created");
        }

        /// <summary>
        /// Mevcut bir TagCloud'u günceller.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud Updated");
        }

        /// <summary>
        /// Bir TagCloud'u siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("TagCloud Deleted");
        }
    }
}
