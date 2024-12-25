using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.AboutHandlers
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IRepository<About> repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new About
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = request.UpdatedDate,
            });
        }
    }
}
