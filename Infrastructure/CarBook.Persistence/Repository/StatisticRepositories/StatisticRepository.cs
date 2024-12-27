using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Common.Enums;
using CarBook.Persistence.Context;
using System.ComponentModel.DataAnnotations;

namespace CarBook.Persistence.Repository.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext context;
        public StatisticRepository(CarBookContext context)
        {
            this.context = context;
        }
        public int GetCarCount()
        {
            var data = context.Cars.Count();
            return data;
        }
        public int GetLocationCount()
        {
            var data = context.Locations.Count();
            return data;
        }
        public int GetAuthorCount()
        {
            var data = context.Authors.Count();
            return data;
        }
        public int GetBlogCount()
        {
            var data = context.Blogs.Count();
            return data;
        }
        public int GetBrandCount()
        {
            var data = context.Brands.Count();
            return data;
        }
        public decimal AverageDailyRentPrice()
        {
            var data = context.CarPricings.Where(x => x.PricingType == Pricing.Daily).Average(x => x.Amount);
            return data;
        }
        public decimal AverageWeeklyRentPrice()
        {
            var data = context.CarPricings.Where(x => x.PricingType == Pricing.Weekly).Average(x => x.Amount);
            return data;
        }
        public decimal AverageMonthlyRentPrice()
        {
            var data = context.CarPricings.Where(x => x.PricingType == Pricing.Monthly).Average(x => x.Amount);
            return data;
        }
        public int GetCarCountByTransmissionIsAuto()
        {
            var data = context.Cars.Where(x => x.Transmission == Transmission.Automatic).Count();
            return data;
        }
        public string BrandNameByMaxCarCount()
        {
            throw new NotImplementedException();
        }
        public string BlogTitleByMaxComment()
        {
            throw new NotImplementedException();
        }
        public int GetCarCountKmLessThen1000()
        {
            var data = context.Cars.Where(x => x.Km < 1000).Count();
            return data;
        }
        public int GetCarCountByFuelType()
        {
            var data = context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return data;
        }
        public int GetCarCountElectric()
        {
            var data = context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return data;
        }
        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //var data = context.CarPricings.Where(x => x.PricingType == Pricing.Daily).OrderByDescending(x => x.Amount).Take(1);
            //return data;
            throw new NotImplementedException();

        }
        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }
    }
}
