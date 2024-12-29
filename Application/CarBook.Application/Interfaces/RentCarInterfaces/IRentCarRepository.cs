using CarBook.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook.Application.Interfaces.RentCarInterfaces
{
    public interface IRentCarRepository
    {
        Task<List<RentCar>> GetByFilter(Expression<Func<RentCar, bool>> filter);
    }
}
