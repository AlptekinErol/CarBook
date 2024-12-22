using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudsQueries
{
    public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResult>>
    {
    }
}
