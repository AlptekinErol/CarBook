﻿using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var data = carRepository.GetCarListWithBrands();
            return data.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name, // özel repo sayesinde ilişkili marka verisine ulaştık
                BrandId = x.BrandId,
                CarId = x.Id,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                CoverImageUrl = x.CoverImageUrl,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
