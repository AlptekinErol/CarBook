using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetCarCountByTransmissionAutoQueryHandler : IRequestHandler<GetCarCountByTransmissionAutoQuery, GetCarCountByTransmissionAutoQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetCarCountByTransmissionAutoQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetCarCountByTransmissionAutoQueryResult> Handle(GetCarCountByTransmissionAutoQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.GetCarCountByTransmissionIsAuto();
            return new GetCarCountByTransmissionAutoQueryResult
            {
                CarCount = data,
            };
        }
    }
}
