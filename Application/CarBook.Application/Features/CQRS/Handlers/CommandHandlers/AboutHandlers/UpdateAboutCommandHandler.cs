using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var data = await repository.GetByIdAsync(command.AboutId);

            data.Title = command.Title;
            data.Description = command.Description;
            data.CreatedDate = command.CreatedDate;
            data.ImageUrl = command.ImageUrl;
            data.UpdatedDate = DateTime.Now;
            await repository.UpdateAsync(data);
        }
    }
}
