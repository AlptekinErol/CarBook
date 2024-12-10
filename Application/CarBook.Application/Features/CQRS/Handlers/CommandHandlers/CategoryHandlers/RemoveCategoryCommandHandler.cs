using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> repository;
        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var data = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(data);
        }
    }
}
