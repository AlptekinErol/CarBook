using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class FooterAddress : EntityBase
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
    }
}
