using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Blog : EntityBase
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public List<TagCloud> TagClouds { get; set; }
    }
}
