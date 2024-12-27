using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        private readonly IRepository<Banner> repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);  // Db'den gelen data yani Entity
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
