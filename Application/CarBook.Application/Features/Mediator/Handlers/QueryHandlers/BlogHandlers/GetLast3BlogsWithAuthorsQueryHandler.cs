using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository blogRepository;
        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var data = await blogRepository.GetLast3BlogsWithAuthor();
            return data.Select(x => new GetLast3BlogsWithAuthorsQueryResult
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
