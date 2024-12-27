using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Testimonial : EntityBase
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
