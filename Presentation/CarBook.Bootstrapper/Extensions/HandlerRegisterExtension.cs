using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Bootstrapper.Extensions
{
    public static class HandlerRegisterExtension
    {
        public static IServiceCollection HandlerRegister(this IServiceCollection services)
        {
            services.AddAboutHandlers();
            services.AddBrandHandlers();
            services.AddBannerHandlers();

            return services;
        }
    }
}
