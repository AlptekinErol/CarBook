using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.TagCloudsResults
{
    public class GetTagCloudQueryResult
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
