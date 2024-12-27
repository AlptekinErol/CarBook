using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
