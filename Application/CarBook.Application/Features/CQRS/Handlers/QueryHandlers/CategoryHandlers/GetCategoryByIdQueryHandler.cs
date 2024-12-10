using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> repository;
        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var data = await repository.GetByIdAsync(query.Id);
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
