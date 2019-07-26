using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Service;
using Storage;
using Infra.Data;
using System.IO;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace MainApp
{
    class Program
    {
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configur = builder.Build();

            var services = new ServiceCollection()
                .AddLogging(options => options.AddConsole())
                .AddDbContext<FileDbContext>(options => options
                .UseSqlServer(configur.GetConnectionString("fileDb")));

            services.AddTransient<IFileService, FileService>();
            services.AddScoped<IFileStore, FileStore>();
            services.AddTransient<IBootstrapper, Bootstrapper>();

            var serviceProvider = services.BuildServiceProvider();
            var bootstrapper = serviceProvider.GetService<IBootstrapper>();
            bootstrapper.Run().GetAwaiter().GetResult();
        }
    }
}
