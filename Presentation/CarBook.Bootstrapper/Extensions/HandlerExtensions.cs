using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Bootstrapper.Extensions
{
    public static class HandlerExtensions
    {
        public static IServiceCollection AddAboutHandlers(this IServiceCollection services)
        {
            // About
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();

            return services;
        }
        public static IServiceCollection AddBrandHandlers(this IServiceCollection services)
        {
            // Brand
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();

            return services;
        }
        public static IServiceCollection AddBannerHandlers(this IServiceCollection services)
        {
            // Banner
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();

            return services;
        }
        public static IServiceCollection AddCarHandlers(this IServiceCollection services)
        {
            // Banner
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

            return services;
        }
    }
}
