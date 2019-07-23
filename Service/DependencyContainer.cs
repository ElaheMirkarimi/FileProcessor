using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Service
{
    public class DependencyContainer
    {
        //public DependencyContainer(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //public IConfiguration Configuration { get; }
        public static IServiceCollection RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<FileDBContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["FileDb"].ConnectionString));
            services.AddScoped<IService, Services>();
            services.AddScoped<IStore, Store>();
            return services;
        }
    }
}
