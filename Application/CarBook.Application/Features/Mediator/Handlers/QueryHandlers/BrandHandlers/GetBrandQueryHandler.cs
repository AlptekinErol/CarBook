using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BrandHandlers
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
    {
        private readonly IRepository<Brand> repository;
        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetBrandQueryResult
            {
                BrandId = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
