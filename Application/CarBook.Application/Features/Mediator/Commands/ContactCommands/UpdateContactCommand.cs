using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ContactCommands
{
    public class UpdateContactCommand : IRequest
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
