using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CarPicingHandler
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimerPeriodQueryResult>>
    {
        private readonly ICarPricingRepository carPricingRepository;
        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }
        public async Task<List<GetCarPricingWithTimerPeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var data = await carPricingRepository.GetCarPricingWithTimePeriod();

            return data.Select(x => new GetCarPricingWithTimerPeriodQueryResult
            {
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Brand = x.Brand,
                DailyAmount = x.DailyAmount,
                WeeklyAmount = x.WeeklyAmount,
                MonthlyAmount = x.MonthlyAmount,
            }).ToList();
        }
    }
}
