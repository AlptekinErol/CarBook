using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Common.Enums;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CarPicingHandler
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingsWithCarQueryResult>>
    {
        private readonly ICarPricingRepository carPricingRepository;
        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }
        public async Task<List<GetCarPricingsWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var data = await carPricingRepository.GetCarsWithPricings();
            return data.Select(x => new GetCarPricingsWithCarQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                PricingAmount = x.Amount,
                PricingName = Enum.IsDefined(typeof(Pricing), x.PricingType)
                    ? x.PricingType.ToString()
                    : "Unknown Pricing" // Eğer enum'a uymayan bir değer varsa
            }).ToList();
        }
    }
}
