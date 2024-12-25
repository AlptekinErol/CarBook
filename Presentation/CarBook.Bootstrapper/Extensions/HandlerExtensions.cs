using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.ContactHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Bootstrapper.Extensions
{
    public static class HandlerExtensions
    {
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
            services.AddScoped<Get5CarWithBrandQueryHandler>();

            return services;
        }
        public static IServiceCollection AddCategoryHandlers(this IServiceCollection services)
        {
            // Banner
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();

            return services;
        }
        public static IServiceCollection AddContactHandlers(this IServiceCollection services)
        {
            // Banner
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();

            return services;
        }
    }
}
