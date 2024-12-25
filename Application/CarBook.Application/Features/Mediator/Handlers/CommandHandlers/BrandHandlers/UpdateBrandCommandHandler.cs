using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IRepository<Brand> repository;
        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.BrandId);
            data.Name = request.Name;
            await repository.UpdateAsync(data);
        }
    }
}
