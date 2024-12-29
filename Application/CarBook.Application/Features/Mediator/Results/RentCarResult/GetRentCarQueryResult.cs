namespace CarBook.Application.Features.Mediator.Results.RentCarResult
{
    public class GetRentCarQueryResult
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal PricingAmount { get; set; }
    }
}

