using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Common.Enums;
using CarBook.Domain.Entities;
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
        public async Task<List<CarPricing>> GetCarsWithPricings()
        {
            var data = await context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Where(x => x.PricingType == Pricing.Daily).ToListAsync(); // Sadece Daily olanları filtreler
            return data;
        }
    }
}
