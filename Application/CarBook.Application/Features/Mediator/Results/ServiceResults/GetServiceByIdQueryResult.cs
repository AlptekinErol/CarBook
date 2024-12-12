namespace CarBook.Application.Features.Mediator.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public int ServiceId { get; set; }
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
