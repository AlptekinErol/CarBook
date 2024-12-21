using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BlogHandlers
{
    public class GetBlogsWithAuthorQueryHandler : IRequestHandler<GetBlogsWithAuthorQuery, List<GetBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository blogRepository;
        public GetBlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<List<GetBlogsWithAuthorQueryResult>> Handle(GetBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var data = await blogRepository.GetBlogsWithAuthor();
            return data.Select(x => new GetBlogsWithAuthorQueryResult
            {
                BlogId = x.Id,
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                AuthorName = x.Author.AuthorName,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            }).ToList();
        }
    }
}
