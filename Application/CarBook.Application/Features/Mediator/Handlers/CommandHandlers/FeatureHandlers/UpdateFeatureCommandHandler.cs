using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> repository;
        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.FeatureId);
            data.Name = request.Name;
            await repository.UpdateAsync(data);
        }
    }
}
