using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler : IRequestHandler<GetCarWithBrandQuery, List<GetCarWithBrandQueryResult>>
    {
        private readonly ICarRepository carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle(GetCarWithBrandQuery request, CancellationToken cancellationToken)
        {
            var data = carRepository.GetCarListWithBrands();
            return data.Select(x => new GetCarWithBrandQueryResult
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
