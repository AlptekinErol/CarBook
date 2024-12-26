using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CommentHandlers
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
        private readonly ICommentRepository commentRepository;
        public GetCommentByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var data = await commentRepository.GetCommentByBlogId(request.BlogId);
            return data.Select(x => new GetCommentByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                CommentId = x.Id,
                Content = x.Content,
                Name = x.Name,
            }).ToList();
        }
    }
}
