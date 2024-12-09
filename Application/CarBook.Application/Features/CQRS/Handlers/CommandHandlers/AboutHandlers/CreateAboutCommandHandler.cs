using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateAboutCommand command)
        {
            await repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate= DateTime.UtcNow,
            });
        }
    }
}
