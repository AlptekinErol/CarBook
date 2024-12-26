using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByBlogIdQuery:IRequest<List<GetCommentByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }
        public GetCommentByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
