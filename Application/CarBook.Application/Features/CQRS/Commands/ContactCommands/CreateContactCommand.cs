namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class CreateContactCommand
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
