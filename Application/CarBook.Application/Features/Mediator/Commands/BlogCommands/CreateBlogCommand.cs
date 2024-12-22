using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
