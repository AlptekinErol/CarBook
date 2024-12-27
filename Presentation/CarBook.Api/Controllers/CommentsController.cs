using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CommentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var data = await mediator.Send(new GetCommentQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var data = await mediator.Send(new GetCommentByIdQuery(id));
            return Ok(data);
        }

        [HttpGet("CommentByBlog")]
        public async Task<IActionResult> GetCommentByBlogId(int id)
        {
            var data = await mediator.Send(new GetCommentByBlogIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await mediator.Send(command);
            return Ok("Comment Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await mediator.Send(command);
            return Ok("Comment Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(RemoveCommentCommand command)
        {
            await mediator.Send(command);
            return Ok("Comment Deleted");
        }
    }
}
