using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetAverageMonthlyRentPriceQueryHandler : IRequestHandler<GetAverageMonthlyRentPriceQuery, GetAverageMonthlyRentPriceQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetAverageMonthlyRentPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetAverageMonthlyRentPriceQueryResult> Handle(GetAverageMonthlyRentPriceQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.AverageMonthlyRentPrice();
            return new GetAverageMonthlyRentPriceQueryResult
            {
                Price = data,
            };
        }
    }
}
