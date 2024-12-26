using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repository.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext context;
        public CarRepository(CarBookContext context)
        {
            this.context = context;
        }

        public List<Car> Get5CarWithBrands()
        {
            var data = context.Cars.Include(x => x.Brand).OrderByDescending(x => x.Id).Take(5).ToList();
            return data;
        }

        public int GetCarCount()
        {
            var data = context.Cars.Count();
            return data;
        }

        public List<Car> GetCarListWithBrands()
        {
            var data = context.Cars.Include(x => x.Brand).ToList();
            return data;
        }
    }
}
