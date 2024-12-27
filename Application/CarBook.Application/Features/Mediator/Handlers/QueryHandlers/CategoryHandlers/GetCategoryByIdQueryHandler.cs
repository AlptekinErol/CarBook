using CarBook.Application.Features.Mediator.Queries.CategoryQueries;
using CarBook.Application.Features.Mediator.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> repository;
        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = data.Id,
                Name = data.Name,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate
            };
        }
    }
}
