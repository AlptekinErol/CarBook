using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetBrandNameByMaxCarCountQueryHandler : IRequestHandler<GetBrandNameByMaxCarCountQuery, GetBrandNameByMaxCarCountQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;
        public GetBrandNameByMaxCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetBrandNameByMaxCarCountQueryResult> Handle(GetBrandNameByMaxCarCountQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.BrandNameByMaxCarCount();
            return new GetBrandNameByMaxCarCountQueryResult
            {
                BrandName = data,
            };
        }
    }
}
