using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;


namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.StatisticHandlers
{
    public class GetBlogTitleByMaxCommentQueryHandler
    {
        private readonly IStatisticRepository statisticRepository;
        public GetBlogTitleByMaxCommentQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public async Task<GetBlogTitleByMaxCommentQueryResult> Handle(GetBlogTitleByMaxCommentQuery request, CancellationToken cancellationToken)
        {
            var data = statisticRepository.BlogTitleByMaxComment();
            return new GetBlogTitleByMaxCommentQueryResult
            {
                BlogTitle = data,
            };
        }
    }
}
