using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class CreateServiceCommand:IRequest
    {
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
