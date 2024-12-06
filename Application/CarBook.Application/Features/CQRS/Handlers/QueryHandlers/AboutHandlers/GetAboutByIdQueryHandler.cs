using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> repository;
        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query) // => GetXXXQuery burada parametreleri tutan sınıf bu yüzden query.Id ye ulaştık
        {
            var data = await repository.GetByIdAsync(query.Id);
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
