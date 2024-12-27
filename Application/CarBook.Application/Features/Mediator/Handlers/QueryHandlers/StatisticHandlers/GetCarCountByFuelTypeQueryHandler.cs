using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetCarCountByFuelTypeQueryHandler : IRequestHandler<GetCarCountByFuelTypeQuery, GetCarCountByFuelTypeQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetCarCountByFuelTypeQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetCarCountByFuelTypeQueryResult> Handle(GetCarCountByFuelTypeQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.GetCarCountByFuelType();
            return new GetCarCountByFuelTypeQueryResult
            {
                CarCount = data,
            };
        }
    }
}
