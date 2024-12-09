using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;
        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var data = await repository.GetByIdAsync(command.Id);
            await repository.RemoveAsync(data);
        }
    }
}
