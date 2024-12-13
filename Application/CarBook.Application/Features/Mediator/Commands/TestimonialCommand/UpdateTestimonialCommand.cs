using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommand
{
    public class UpdateTestimonialCommand:IRequest
    {
        public int TestimonialId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
