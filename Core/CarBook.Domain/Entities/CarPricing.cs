using CarBook.Domain.Common;
using CarBook.Domain.Enums;

namespace CarBook.Domain.Entities
{
    public class CarPricing : EntityBase
    {
        public int CarId { get; set; }
        public Pricing PricingType { get; set; }
        public decimal Amount { get; set; }
        public Car Car { get; set; }
    }
}
