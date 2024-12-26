using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly IRepository<Car> repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetCarQueryResult
            {
                BrandId = x.BrandId,
                CarId = x.Id,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                CoverImageUrl = x.CoverImageUrl,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
