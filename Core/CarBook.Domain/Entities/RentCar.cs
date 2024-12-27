using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class RentCar : EntityBase
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CarAvailable { get; set; }
    }
}
