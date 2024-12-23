using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Comment : EntityBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
    }
}
