using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Common.Enums;
using CarBook.Domain.Entities;
using CarBook.DTO.CarPricingDtos;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repository.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext context;
        public CarPricingRepository(CarBookContext context)
        {
            this.context = context;
        }

        public async Task<List<CarPricingDto>> GetCarPricingWithTimePeriod()
        {
            var result = await (
                from carPricing in context.CarPricings
                join car in context.Cars on carPricing.CarId equals car.Id
                join brand in context.Brands on car.BrandId equals brand.Id
                group carPricing by new { car.Model, brand.Name } into grouped
                select new CarPricingDto
                {
                    Brand = grouped.Key.Name,

                    Model = grouped.Key.Model,

                    HourlyAmount = grouped.Where(p => p.PricingType == Pricing.Hourly)
                                    .Select(p => (decimal?)p.Amount)
                                    .FirstOrDefault() ?? 0,
                    DailyAmount = grouped.Where(p => p.PricingType == Pricing.Daily)
                                   .Select(p => (decimal?)p.Amount)
                                   .FirstOrDefault() ?? 0,
                    WeeklyAmount = grouped.Where(p => p.PricingType == Pricing.Weekly)
                                    .Select(p => (decimal?)p.Amount)
                                    .FirstOrDefault() ?? 0,
                    MonthlyAmount = grouped.Where(p => p.PricingType == Pricing.Monthly)
                                     .Select(p => (decimal?)p.Amount)
                                     .FirstOrDefault() ?? 0
                }
            )
            .OrderBy(x => x.Brand)
            .ThenBy(x => x.Model)
            .ToListAsync();

            return result;
        }



        public async Task<List<CarPricing>> GetCarsWithPricings()
        {
            var data = await context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Where(x => x.PricingType == Pricing.Daily).ToListAsync(); // Sadece Daily olanları filtreler
            return data;
        }
    }
}
