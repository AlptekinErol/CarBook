using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, GetBrandByIdQueryResult>
    {
        private readonly IRepository<Brand> repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.BrandId);
            return new GetBrandByIdQueryResult
            {
                BrandId = data.Id,
                Name = data.Name,
            };
        }
    }
}
