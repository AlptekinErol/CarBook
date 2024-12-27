using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarBrandAndModelByRentPriceDailyMaxQuery : IRequest<GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
    {
    }
}
