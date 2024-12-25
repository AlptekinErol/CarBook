namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate{ get; set; }
    }
}
