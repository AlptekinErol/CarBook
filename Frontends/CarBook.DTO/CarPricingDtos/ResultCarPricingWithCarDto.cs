namespace CarBook.DTO.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal PricingAmount { get; set; }
        public string PricingName { get; set; }
    }
}
