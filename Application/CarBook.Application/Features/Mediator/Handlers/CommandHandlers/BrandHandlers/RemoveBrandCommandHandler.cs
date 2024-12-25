using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers
{
    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommand>
    {
        private readonly IRepository<Brand> repository;
        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
