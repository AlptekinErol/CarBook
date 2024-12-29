namespace CarBook.DTO.RentCarDtos
{
    public class FilterRentCarDto
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal PricingAmount { get; set; }
    }
}
