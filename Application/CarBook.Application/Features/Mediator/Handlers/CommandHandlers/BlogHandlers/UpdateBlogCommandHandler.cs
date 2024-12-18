using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> repository;
        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.BlogId);
            data.AuthorId = request.AuthorId;
            data.Title = request.Title;
            data.CoverImageUrl = request.CoverImageUrl;
            data.CategoryId = request.CategoryId;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;

            await repository.UpdateAsync(data);
        }
    }
}
