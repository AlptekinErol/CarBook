﻿using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class CarFeature : EntityBase
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public bool Available { get; set; }
    }
}
