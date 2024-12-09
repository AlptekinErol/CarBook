using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var data = await repository.GetByIdAsync(query.Id);  // Db'den gelen data yani Entity
            return new GetBannerByIdQueryResult                  // Db'den gelen datayı buradaki DTO yada Result'a aktarım
            {
                BannerId = data.Id,
                Description = data.Description,
                Title = data.Title,
                VideoDescription = data.VideoDescription,
                VideoUrl = data.VideoUrl
            };
        }
    }
}
