using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudsCommands
{
    public class CreateTagCloudCommand : IRequest
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
