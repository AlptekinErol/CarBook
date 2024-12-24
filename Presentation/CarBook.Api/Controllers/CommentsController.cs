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

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            commentRepository.Create(comment);
            return Ok("Comment Created");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var data = commentRepository.GetById(id);
            commentRepository.Remove(data);
            return Ok("Comment Removed");
        }

        [HttpPut]

        public IActionResult UpdateComment(Comment comment)
        {
            commentRepository.Update(comment);
            return Ok("Comment Updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var data = commentRepository.GetById(id);
            return Ok(data);
        }
    }
}
