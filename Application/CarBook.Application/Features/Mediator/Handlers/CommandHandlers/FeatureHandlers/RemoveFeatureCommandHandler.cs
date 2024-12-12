using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> repository;
        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
