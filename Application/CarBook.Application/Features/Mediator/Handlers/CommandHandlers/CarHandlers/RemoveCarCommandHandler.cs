using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CarHandlers
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand>
    {
        private readonly IRepository<Car> repository;
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
