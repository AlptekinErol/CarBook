using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
    public class UpdateAuthorCommand : IRequest
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
