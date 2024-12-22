using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudsQueries
{
    public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
    {
        public int Id { get; set; }
        public GetTagCloudByIdQuery(int id)
        {
            Id = id;
        }
    }
}
