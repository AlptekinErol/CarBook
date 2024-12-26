using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator mediator;
        public BlogsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var data = await mediator.Send(new GetBlogQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var data = await mediator.Send(new GetBlogByIdQuery(id));
            return Ok(data);
        }

        [HttpGet("Last3BlogsWithAuthor")]
        public async Task<IActionResult> GetLast3BlogsWithAuthor()
        {
            var data = await mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(data);
        }

        [HttpGet("BlogsWithAuthor")]
        public async Task<IActionResult> GetBlogsWithAuthor()
        {
            var data = await mediator.Send(new GetBlogsWithAuthorQuery());
            return Ok(data);
        }

        [HttpGet("BlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var data = await mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await mediator.Send(command);
            return Ok("Blog Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await mediator.Send(command);
            return Ok("Blog Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(RemoveBlogCommand command)
        {
            await mediator.Send(command);
            return Ok("Blog Deleted");
        }
    }
}
