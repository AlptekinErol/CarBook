using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.AboutHandlers
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
    {
        private readonly IRepository<About> repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
