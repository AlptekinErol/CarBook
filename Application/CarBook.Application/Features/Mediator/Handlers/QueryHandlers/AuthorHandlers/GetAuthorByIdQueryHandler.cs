using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Authors.Mediator.Handlers.QueryHandlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> repository;
        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorId = data.Id,
                AuthorName = data.AuthorName,
                ImageUrl = data.ImageUrl,
                Description = data.Description,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate,
            };
        }
    }
}
