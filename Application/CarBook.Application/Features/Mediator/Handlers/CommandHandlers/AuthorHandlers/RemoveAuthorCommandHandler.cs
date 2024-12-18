using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.AuthorHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> repository;
        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
