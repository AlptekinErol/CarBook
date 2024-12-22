using CarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.TagCloudCommandHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> repository;
        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.TagCloudId);
            data.BlogId = request.BlogId;
            data.Title = request.Title;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;

            await repository.UpdateAsync(data);
        }
    }
}
