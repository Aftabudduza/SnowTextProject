using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SnowTextProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.ConfigureServices
{
    public class ExtractAutoMapperServices
    {
        internal static void ExtractIBAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductManager).Assembly);
            services.AddAutoMapper(typeof(SizeManager).Assembly);
            services.AddAutoMapper(typeof(PasswordResetManager).Assembly);
           
        }
    }
}
