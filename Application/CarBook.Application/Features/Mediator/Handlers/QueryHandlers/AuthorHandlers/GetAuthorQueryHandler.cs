using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {

        private readonly IRepository<Author> repository;
        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetAuthorQueryResult
            {
                AuthorId = x.Id,
                AuthorName = x.AuthorName,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
