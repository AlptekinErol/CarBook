using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommand
{
    public class CreateTestimonialCommand:IRequest
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
