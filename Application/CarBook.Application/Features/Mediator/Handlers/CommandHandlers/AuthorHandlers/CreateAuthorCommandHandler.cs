using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<Author> repository;
        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Author
            {
                AuthorName = request.AuthorName,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = request.UpdatedDate,
            });
        }
    }
}
