using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Bootstrapper.Extensions
{
    public static class MediatRExtensions
    {
        public static void MediatRRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatRExtensions).Assembly));
        }
    }
}
