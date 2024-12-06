using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class CarDescription : EntityBase
    {
        public int CarId { get; set; }
        public string Details { get; set; }
        public Car Car { get; set; }

    }
}
