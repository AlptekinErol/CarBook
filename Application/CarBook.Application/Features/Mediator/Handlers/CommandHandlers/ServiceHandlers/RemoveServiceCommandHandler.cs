using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IRepository<Service> repository;
        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
