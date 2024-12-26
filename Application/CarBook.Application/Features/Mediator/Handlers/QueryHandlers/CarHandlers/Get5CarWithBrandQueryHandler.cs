using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CarHandlers
{
    public class Get5CarWithBrandQueryHandler : IRequestHandler<Get5CarWithBrandQuery, List<Get5CarWithBrandQueryResult>>
    {
        private readonly ICarRepository carRepository;
        public Get5CarWithBrandQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public async Task<List<Get5CarWithBrandQueryResult>> Handle(Get5CarWithBrandQuery request, CancellationToken cancellationToken)
        {
            var data = carRepository.Get5CarWithBrands();
            return data.Select(x => new Get5CarWithBrandQueryResult
            {
                BrandName = x.Brand.Name, // özel repo sayesinde ilişkili marka verisine ulaştık
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
