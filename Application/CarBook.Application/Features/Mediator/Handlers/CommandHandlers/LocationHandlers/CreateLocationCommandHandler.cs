using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> repository;
        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Location
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate
            });
        }
    }
}
