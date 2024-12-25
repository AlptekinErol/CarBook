using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Bootstrapper.Extensions
{
    public static class HandlerRegisterExtension
    {
        public static IServiceCollection HandlerRegister(this IServiceCollection services)
        {
            services.AddBrandHandlers();
            services.AddBannerHandlers();
            services.AddCarHandlers();
            services.AddCategoryHandlers();
            services.AddContactHandlers();

            return services;
        }
    }
}
