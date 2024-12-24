using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> commentRepository;
        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult GetCommentList()
        {
            var data = commentRepository.GetAll();
            return Ok(data);
        }
    }
}
