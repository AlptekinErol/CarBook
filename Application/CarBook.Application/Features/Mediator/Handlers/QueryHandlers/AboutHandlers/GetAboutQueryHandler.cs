using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {

            var data = await repository.GetAllAsync();  // => veriyi ToListAsync ile belleğe kaydediyor ve veri artık hızlı bir şekilde erişebiliyoruz async olmasına gerek kalmıyor
            return data.Select(x => new GetAboutQueryResult
            {
                AboutId = x.Id,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl
            }).ToList();  // => ToListAsync kullanmamıza gerek kalmıyor
        }
    }
}
