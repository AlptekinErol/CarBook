using CarBook.Domain.Common;
using CarBook.Common.Enums;

namespace CarBook.Domain.Entities
{
    public class Car : EntityBase
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public Transmission Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentCar> RentCars { get; set; }
        public List<RentProcess> RentProcesses { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
