using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class About : EntityBase
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
