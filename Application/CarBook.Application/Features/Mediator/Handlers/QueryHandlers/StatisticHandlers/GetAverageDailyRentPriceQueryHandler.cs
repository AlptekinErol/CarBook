using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetAverageDailyRentPriceQueryHandler : IRequestHandler<GetAverageDailyRentPriceQuery, GetAverageDailyRentPriceQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetAverageDailyRentPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetAverageDailyRentPriceQueryResult> Handle(GetAverageDailyRentPriceQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.AverageDailyRentPrice();
            return new GetAverageDailyRentPriceQueryResult
            {
                Price = data,
            };
        }
    }
}
