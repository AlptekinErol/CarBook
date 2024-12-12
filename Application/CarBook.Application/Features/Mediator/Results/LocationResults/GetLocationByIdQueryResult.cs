namespace CarBook.Application.Features.Mediator.Results.LocationResults
{
    public class GetLocationByIdQueryResult 
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
