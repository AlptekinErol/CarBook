namespace CarBook.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
