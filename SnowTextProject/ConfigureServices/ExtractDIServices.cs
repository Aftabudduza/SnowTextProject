using Microsoft.Extensions.DependencyInjection;
using SnowTextProject.Interface;
using SnowTextProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.ConfigureServices
{
    public class ExtractDIServices
    {
        public static void ExtractIBServices(IServiceCollection services)
        {
            services.AddScoped<IProduct, ProductManager>();
            services.AddScoped<ISize, SizeManager>();
            services.AddScoped<IPasswordReset, PasswordResetManager>();

        }
    }
}
