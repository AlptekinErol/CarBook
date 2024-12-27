namespace CarBook.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal AverageDailyRentPrice();
        decimal AverageWeeklyRentPrice();
        decimal AverageMonthlyRentPrice();
        int GetCarCountByTransmissionIsAuto();
        string BrandNameByMaxCarCount();
        string BlogTitleByMaxComment();
        int GetCarCountKmLessThen1000();
        int GetCarCountByFuelType();
        int GetCarCountElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();

    }
}
