using CarBook.Domain.Entities;
using CarBook.DTO.CarPricingDtos;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarsWithPricings();
        Task<List<CarPricingDto>> GetCarPricingWithTimePeriod();
    }
}
