using CarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.TagCloudCommandHandlers
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> repository;
        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new TagCloud
            {
                BlogId = request.BlogId,
                Title = request.Title,
                CreatedDate = DateTime.Now,
                UpdatedDate = request.UpdatedDate,
            });
        }
    }
}
