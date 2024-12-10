using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var data = await repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandId = data.BrandId,
                CarId = data.Id,
                BigImageUrl = data.BigImageUrl,
                Fuel = data.Fuel,
                Km = data.Km,
                Luggage = data.Luggage,
                CoverImageUrl = data.CoverImageUrl,
                Model = data.Model,
                Seat = data.Seat,
                Transmission = data.Transmission
            };
        }
    }
}
