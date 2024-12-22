using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.TagCloudsHandlers
{
    public class GetTagCloudsByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> repository;
        public GetTagCloudsByIdQueryHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }
        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                TagCloudId = data.Id,
                BlogId = data.BlogId,
                Title = data.Title,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate,
            };
        }
    }
}
