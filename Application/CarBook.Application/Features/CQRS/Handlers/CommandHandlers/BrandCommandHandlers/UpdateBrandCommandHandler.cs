using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;
        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateBrandCommand command)
        {
            var data = await repository.GetByIdAsync(command.BrandId);
            data.Name = command.Name;
            data.Cars = command.Cars;
            await repository.UpdateAsync(data);
        }
    }
}
