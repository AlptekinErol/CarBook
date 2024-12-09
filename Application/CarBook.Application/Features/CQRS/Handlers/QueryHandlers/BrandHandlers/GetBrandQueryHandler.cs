
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> repository;
        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBrandQueryResult>> Handle()
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
