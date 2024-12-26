using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> repository;
        public CreateCommentCommandHandler(IRepository<Comment> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Comment
            {
                Name = request.Name,
                BlogId = request.BlogId,
                Content = request.Content,
                CreatedDate = DateTime.Now,
                UpdatedDate = request.UpdatedDate,
            });
        }
    }
}
