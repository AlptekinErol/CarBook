using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResults>>
    {
        private readonly IRepository<SocialMedia> repository;
        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetSocialMediaQueryResults>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetSocialMediaQueryResults
            {
                SocialMediaId = x.Id,
                Icon = x.Icon,
                Name = x.Name,
                Url = x.Url,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToList();
        }
    }
}
