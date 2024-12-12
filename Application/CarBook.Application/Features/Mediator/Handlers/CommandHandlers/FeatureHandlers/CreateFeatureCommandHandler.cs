using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> repository;
        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Feature
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate,
            });
        }
    }
}
