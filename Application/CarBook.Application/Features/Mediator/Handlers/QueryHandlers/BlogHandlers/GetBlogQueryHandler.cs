using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> repository;
        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetBlogQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId = x.Id,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToList();
        }
    }
}
