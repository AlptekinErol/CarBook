using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var data = await repository.GetByIdAsync(query.BrandId);
            return new GetBrandByIdQueryResult
            {
                BrandId = data.Id,
                Name = data.Name,
                Cars = data.Cars
            };
        }
    }
}
