using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudsQueries
{
    public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetTagCloudByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
