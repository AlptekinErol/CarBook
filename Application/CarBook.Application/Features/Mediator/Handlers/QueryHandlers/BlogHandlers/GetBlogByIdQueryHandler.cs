using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> repository;
        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogId = data.Id,
                Title = data.Title,
                CoverImageUrl = data.CoverImageUrl,
                AuthorId = data.AuthorId,
                CategoryId = data.CategoryId,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate,
            };
        }
    }
}
