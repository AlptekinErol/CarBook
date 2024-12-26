using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Category
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = request.UpdatedDate,
                Name = request.Name,
            });
        }
    }
}
