namespace CarBook.DTO.CarPricingDtos
{
    public class ResultCarPricingListWithModelDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal HourlyAmount { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
