using CarBook.Application.Features.CQRS.Commands.Brands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;
        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await repository.CreateAsync(new Brand
            {
                Name = command.Name
            });
        }
    }
}
