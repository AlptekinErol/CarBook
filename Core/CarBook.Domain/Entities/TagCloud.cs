using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class TagCloud : EntityBase
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
