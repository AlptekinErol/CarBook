﻿namespace CarBook.DTO.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDated { get; set; }
    }
}
