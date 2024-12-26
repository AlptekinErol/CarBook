using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ContactHandlers
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
    {
        private readonly IRepository<Contact> repository;
        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
