using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Location:EntityBase
    {
        public string Name { get; set; }
        public List<RentCar> RentCars { get; set; }
    }
}
