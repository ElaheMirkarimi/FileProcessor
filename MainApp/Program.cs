using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Service;
using Storage;
using Infra.Data;
using System.IO;

namespace MainApp
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection()
                .AddLogging(options => options.AddConsole());
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            services.AddSingleton(builder.Build());

            services.AddTransient<IFileDbContextBuilder, FileDbContextBuilder>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFileStore, FileStore>();
            services.AddTransient<IBootstrapper, Bootstrapper>();

            var serviceProvider = services.BuildServiceProvider();
                        
            var bootstrapper = serviceProvider.GetService<IBootstrapper>();
            bootstrapper.Run().GetAwaiter().GetResult();
        }
    }
}
