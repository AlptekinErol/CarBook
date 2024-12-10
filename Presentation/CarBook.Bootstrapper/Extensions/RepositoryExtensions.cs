using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistence.Repository;
using CarBook.Persistence.Repository.CarRepositories;
using Microsoft.Extensions.DependencyInjection;


namespace CarBook.Bootstrapper.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection RepositoryRegister(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // burada typeof repo classların <T> yani generic çalışacağını belirtmemizi sağlıyor
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository)); // özel CarRepository kayıt

            return services;
        }
    }
}
