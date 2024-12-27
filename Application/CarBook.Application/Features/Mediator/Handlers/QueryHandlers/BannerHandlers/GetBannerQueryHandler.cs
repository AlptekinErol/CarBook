using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BannerHandlers
{
    public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
    {
        private readonly IRepository<Banner> repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
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
