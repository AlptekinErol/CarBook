using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetCarCountElectricQueryHandler : IRequestHandler<GetCarCountElectricQuery, GetCarCountElectricQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetCarCountElectricQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetCarCountElectricQueryResult> Handle(GetCarCountElectricQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.GetCarCountElectric();
            return new GetCarCountElectricQueryResult
            {
                CarCount = data,
            };
        }
    }
}
