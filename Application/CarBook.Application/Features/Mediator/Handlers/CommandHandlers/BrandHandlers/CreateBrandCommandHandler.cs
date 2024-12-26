using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.BrandCommandHandlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
    {
        private readonly IRepository<Brand> repository;
        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Brand
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = request.UpdatedDate,

            });
        }
    }
}
