using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> repository;
        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Blog
            {
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                CoverImageUrl = request.CoverImageUrl,
                Title = request.Title,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            });
        }
    }
}
