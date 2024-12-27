﻿using CarBook.Common.Enums;

namespace CarBook.Application.Features.Mediator.Results.CarResults
{
    public class GetCarWithBrandQueryResult
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } // Marka adı ile filtreleme içi
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public Transmission Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
