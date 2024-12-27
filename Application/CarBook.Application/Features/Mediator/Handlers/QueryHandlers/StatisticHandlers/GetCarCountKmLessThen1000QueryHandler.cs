using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetCarCountKmLessThen1000QueryHandler : IRequestHandler<GetCarCountKmLessThen1000Query, GetCarCountKmLessThen1000QueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetCarCountKmLessThen1000QueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetCarCountKmLessThen1000QueryResult> Handle(GetCarCountKmLessThen1000Query request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.GetCarCountKmLessThen1000();
            return new GetCarCountKmLessThen1000QueryResult
            {
                CarCount = data,
            };
        }
    }
}
