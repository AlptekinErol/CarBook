using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetBannerQueryResult  // bu lambda ifadesinde x = Banner oluyor, çünkü repoda Banner belirttik
            {
                BannerId = x.Id,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
