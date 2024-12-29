using CarBook.Application.Interfaces.RentCarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistence.Repository.RentCarRepositories
{
    public class RentCarRepository : IRentCarRepository
    {
        private readonly CarBookContext context;
        public RentCarRepository(CarBookContext context)
        {
            this.context = context;
        }
        public async Task<List<RentCar>> GetByFilter(Expression<Func<RentCar, bool>> filter)
        {
            var values = await context.RentCars.Where(filter).Include(x => x.Car).ThenInclude(x => x.Brand).ToListAsync();
            return values;
        }
    }
}
