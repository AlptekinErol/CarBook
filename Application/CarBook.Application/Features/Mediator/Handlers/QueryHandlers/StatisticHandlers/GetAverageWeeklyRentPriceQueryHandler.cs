using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetAverageWeeklyRentPriceQueryHandler : IRequestHandler<GetAverageWeeklyRentPriceQuery, GetAverageWeeklyRentPriceQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetAverageWeeklyRentPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetAverageWeeklyRentPriceQueryResult> Handle(GetAverageWeeklyRentPriceQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.AverageWeeklyRentPrice();
            return new GetAverageWeeklyRentPriceQueryResult
            {
                Price = data,
            };
        }
    }
}
