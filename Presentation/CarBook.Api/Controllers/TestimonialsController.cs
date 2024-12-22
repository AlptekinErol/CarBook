using CarBook.Application.Features.Mediator.Commands.TestimonialCommand;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator mediator;
        public TestimonialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var data = await mediator.Send(new GetTestimonialQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var data = await mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Testimonial Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Testimonial Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(RemoveTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Testimonial Deleted");
        }
    }
}
