using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class SocialMedia : EntityBase
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
