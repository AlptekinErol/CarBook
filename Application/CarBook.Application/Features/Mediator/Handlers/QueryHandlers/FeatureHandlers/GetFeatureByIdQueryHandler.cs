using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> repository;
        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = data.Id,
                Name = data.Name
            };
        }
    }
}
