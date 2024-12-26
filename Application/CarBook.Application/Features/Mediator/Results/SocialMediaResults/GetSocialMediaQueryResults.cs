namespace CarBook.Application.Features.Mediator.Results.SocialMediaResult
{
    public class GetSocialMediaQueryResults
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
