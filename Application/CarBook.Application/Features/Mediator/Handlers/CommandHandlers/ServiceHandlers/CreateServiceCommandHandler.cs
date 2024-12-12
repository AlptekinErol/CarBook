using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> repository;
        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Service
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            });
        }
    }
}
