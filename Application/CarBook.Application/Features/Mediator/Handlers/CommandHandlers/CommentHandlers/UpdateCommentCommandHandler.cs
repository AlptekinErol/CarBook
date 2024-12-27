using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> repository;
        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.CommentId);
            data.Name = request.Name;
            data.Content = request.Content;
            data.UpdatedDate = DateTime.Now;
            data.CreatedDate = request.CreatedDate;
            await repository.UpdateAsync(data);
        }
    }
}
