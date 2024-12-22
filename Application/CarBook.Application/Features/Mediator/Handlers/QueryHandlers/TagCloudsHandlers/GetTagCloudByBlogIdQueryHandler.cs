using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.TagCloudsHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository repository;
        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var data = repository.GetTagCloudsByBlogId(request.Id);
            return data.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                Title = x.Title,
                TagCloudId = x.Id,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            }).ToList();
        }
    }
}
