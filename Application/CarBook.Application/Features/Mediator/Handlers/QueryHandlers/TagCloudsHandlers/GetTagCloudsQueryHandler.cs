using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.TagCloudsHandlers
{
    public class GetTagCloudsQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> repository;
        public GetTagCloudsQueryHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetTagCloudQueryResult
            {
                TagCloudId = x.Id,
                BlogId = x.BlogId,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            }).ToList();
        }
    }
}
