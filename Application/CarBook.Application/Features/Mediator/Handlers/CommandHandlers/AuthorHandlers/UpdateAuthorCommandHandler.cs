using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> repository;
        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.AuthorId);
            data.AuthorName = request.AuthorName;
            data.Description = request.Description;
            data.ImageUrl = request.ImageUrl;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;

            await repository.UpdateAsync(data);
        }
    }
}
