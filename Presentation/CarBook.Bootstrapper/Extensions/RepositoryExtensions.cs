using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Persistence.Repository;
using CarBook.Persistence.Repository.BlogRepositories;
using CarBook.Persistence.Repository.CarPricingRepositories;
using CarBook.Persistence.Repository.CarRepositories;
using CarBook.Persistence.Repository.CommentRepositories;
using CarBook.Persistence.Repository.TagCloudRepositories;
using Microsoft.Extensions.DependencyInjection;


namespace CarBook.Bootstrapper.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection RepositoryRegister(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // burada typeof repo classların <T> yani generic çalışacağını belirtmemizi sağlıyor
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository)); // özel CarRepository kayıt
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository)); // özel BlogRepository kayıt
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository)); // özel CarPricingRepository kayıt
            services.AddScoped(typeof(ITagCloudRepository), typeof(TagClougRepository)); // özel TagClougRepository kayıt
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository)); // özel TagClougRepository kayıt

            return services;
        }
    }
}
