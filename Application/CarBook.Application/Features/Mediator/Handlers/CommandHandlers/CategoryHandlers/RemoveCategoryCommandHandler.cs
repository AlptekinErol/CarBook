using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
