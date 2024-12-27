using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountKmLessThen1000Query:IRequest<GetCarCountKmLessThen1000QueryResult>
    {
    }
}
