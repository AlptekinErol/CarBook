using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudsCommands
{
    public class RemoveTagCloudCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveTagCloudCommand(int id)
        {
            Id = id;
        }
    }
}
