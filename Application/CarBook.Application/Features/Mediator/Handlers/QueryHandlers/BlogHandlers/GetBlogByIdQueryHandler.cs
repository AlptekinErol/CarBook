using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> repository;
        private readonly ICommentRepository commentRepository;
        public GetBlogByIdQueryHandler(IRepository<Blog> repository, ICommentRepository commentRepository)
        {
            this.repository = repository;
            this.commentRepository = commentRepository;
        }
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogId = data.Id,
                Title = data.Title,
                CoverImageUrl = data.CoverImageUrl,
                CommentCount = await GetCommentCount(request.Id),
                Description = data.Description,
                AuthorId = data.AuthorId,
                CategoryId = data.CategoryId,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate,
            };
        }

        private async Task<int> GetCommentCount(int id)
        {
            var commentCount = await commentRepository.GetCommentCount(id);
            return commentCount;
        }
    }
}
