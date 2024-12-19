namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingsWithCarQueryResult
    {
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal PricingAmount { get; set; }
        public string PricingName { get; set; }
    }
}
