using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> repository;
        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetAboutByIdQueryResult // => bir nevi DTO gibi hareket ediyor response sınıfları
            {
                AboutId = data.Id,
                Description = data.Description,
                ImageUrl = data.ImageUrl,
                Title = data.Title
            };
        }
    }
}
