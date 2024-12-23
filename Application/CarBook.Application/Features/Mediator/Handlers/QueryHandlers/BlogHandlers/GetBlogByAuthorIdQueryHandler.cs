using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository blogRepository;
        public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var data = await blogRepository.GetBlogByAuthorId(request.AuthorId);
            return data.Select(x => new GetBlogByAuthorIdQueryResult
            {
                BlogId = x.Id,
                AuthorId = x.AuthorId,
                AuthorName = x.Author.AuthorName,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,                
            }).ToList();
        }
    }
}
