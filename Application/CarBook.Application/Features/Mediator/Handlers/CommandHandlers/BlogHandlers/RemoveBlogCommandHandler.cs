using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.BlogHandlers
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> repository;
        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
