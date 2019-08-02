using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Service;
using Storage;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

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

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileStore, FileStore>();
            services.AddSingleton<IBootstrapper, Bootstrapper>();

            var serviceProvider = services.BuildServiceProvider();
            var bootstrapper = serviceProvider.GetService<IBootstrapper>();
            bootstrapper.Run().GetAwaiter().GetResult();
        }
    }
}
