using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {

    }
}
