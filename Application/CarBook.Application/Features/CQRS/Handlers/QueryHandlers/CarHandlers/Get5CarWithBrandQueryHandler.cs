using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers
{
    public class Get5CarWithBrandQueryHandler
    {
        private readonly ICarRepository carRepository;
        public Get5CarWithBrandQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public List<Get5CarWithBrandQueryResult> Handle()
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
