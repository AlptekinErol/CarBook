using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class UpdateLocationCommand:IRequest
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
