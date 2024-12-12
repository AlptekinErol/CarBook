using CarBook.Application.Features.Mediator.Queries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> repository;
        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetFeatureQueryResult  // burada x her defasında tek tek list'i dolduran GetFeatureQueryResult nesnesini dolduruyor Select döngü gibi çalışır ve nestedList ile de çalışabilir SelectMany();
            {
                FeatureId = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
