﻿namespace CarBook.DTO.LocationDtos
{
    public class UpdateLocationDto
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}