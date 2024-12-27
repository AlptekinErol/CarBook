using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Feature:EntityBase
    {
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
