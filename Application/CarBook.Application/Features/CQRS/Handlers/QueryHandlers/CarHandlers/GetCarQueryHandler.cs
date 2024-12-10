using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
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
