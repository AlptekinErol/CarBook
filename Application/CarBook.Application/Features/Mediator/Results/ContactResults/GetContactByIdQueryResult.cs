namespace CarBook.Application.Features.Mediator.Results.ContactResults
{
    public class GetContactByIdQueryResult
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
