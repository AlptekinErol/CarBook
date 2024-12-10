using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repository.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext context;
        public CarRepository(CarBookContext context)
        {
            this.context = context;
        }
        public List<Car> GetCarListWithBrands()
        {
            var data = context.Cars.Include(x => x.Brand).ToList();
            return data;
        }
    }
}
