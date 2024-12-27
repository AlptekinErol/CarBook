using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Common.Enums;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
            // select Top(1) Brands.Name, Count(*) as 'ToplamArac' from Cars inner join Brands on Cars.BrandId = Brands.Id Group By Brands.Name Order By ToplamArac Desc 
            var values = context.Cars.GroupBy(x => x.BrandId). // Cars sınıfını BrandId ye göre grupla
                                        Select(y => new        // ardından bunları sql tablosunda ki gibi  BrandId | Count 
                                        {                      //                                             1        4  
                                                               //                                             2        2  
                                            BrandID = y.Key,   // şeklinde listele ama 71. satır OrderBy kullan ve Counta göre descending sırala
                                            Count = y.Count()
                                        }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();  // ilk kaydı Take ile al ve first or default ile kayıt varsa al yoksa default null döndür

            // Yukarıda elde ettiğimiz Satır BrandId = x | Count = x örnek olarak,
            // bu değerde ki id ye eşit olan datayı yakala dedik Where ile, ardıdan o datanın Name'ine Select attık
            string brandName = context.Brands.Where(x => x.Id == values.BrandID).Select(y => y.Name).FirstOrDefault();

            return brandName;
        }
        public string BlogTitleByMaxComment()
        {
            //Select Top(1) BlogId,Count(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc 
            var values = context.Comments.GroupBy(x => x.BlogId).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = context.Blogs.Where(x => x.Id == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;


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
            //Select* From CarPricings where Amount = (select Max(Amount) from CarPricings where PricingId = 2 )  pricingId = 2 daily demek

            decimal amount = context.CarPricings
                .Where(x => x.PricingType == Pricing.Daily) // PricingType'ı Enum da ki Daily'e eşit olan verileri yakala
                .Max(x => x.Amount);                        // bunlardan Amount'a göre max olanı yakala

            int carId = context.CarPricings
                .Where(x => x.Amount == amount)             // CarPricing'de ki Amount değeri bulduğumuzu yukarıdaki amounta eşit olan veriyi yakala
                .Select(x => x.CarId)                       // ilgili verinin CarId sini yakala
                .FirstOrDefault();

            var data = context.Cars
                .Where(x => x.Id == carId)                  // Car Tablosunda yukarıda bulduğumuz CarId'ye eşit olan veriyi yakala ( Araba özelliklerine erişmek için bir nevi inner join)
                .Include(x => x.Brand)                      // inner join Brand'e git çünkü marka değeri lazım
                .Select(x => x.Brand.Name + " " + x.Model)  // Brand den gelen Name ve Cars.Model değerini yakala
                .FirstOrDefault();

            return data ?? "Veri bulunamadı.";              // return et
        }
        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            decimal amount = context.CarPricings
                .Where(x => x.PricingType == Pricing.Daily) // PricingType'ı Enum da ki Daily'e eşit olan verileri yakala
                .Min(x => x.Amount);                        // bunlardan Amount'a göre min olanı yakala

            int carId = context.CarPricings
                .Where(x => x.Amount == amount)             // CarPricing'de ki Amount değeri bulduğumuzu yukarıdaki amounta eşit olan veriyi yakala
                .Select(x => x.CarId)                       // ilgili verinin CarId sini yakala
                .FirstOrDefault();

            var data = context.Cars
                .Where(x => x.Id == carId)                  // Car Tablosunda yukarıda bulduğumuz CarId'ye eşit olan veriyi yakala ( Araba özelliklerine erişmek için bir nevi inner join)
                .Include(x => x.Brand)                      // inner join Brand'e git çünkü marka değeri lazım
                .Select(x => x.Brand.Name + " " + x.Model)  // Brand den gelen Name ve Cars.Model değerini yakala
                .FirstOrDefault();

            return data ?? "Veri bulunamadı.";              // return et
        }
    }
}
