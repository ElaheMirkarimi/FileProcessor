using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Storage;

namespace MainApp
{
    class Program
    {
        private static IServiceProvider _Iservice;
        private const string _connectionString = "Server=DESKTOP-RFQEHJ6;Database=FileProcessor;Trusted_Connection=True;MultipleActiveResultSets=true";

        static void Main()
        {
            RegisterServices();
            Console.WriteLine("Please enter the path of the files: ");
            var filesPath = Console.ReadLine();
            var files = Directory.GetFiles(filesPath);
            var mainService = _Iservice.GetService<IService>();
            mainService.insertFile(files);
            //Task.Run(() => mainService.insertFile(files));
            //Disposeservices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection()
                .AddSingleton<IService, mainService>();
            collection.AddDbContext<FileDBContext>(options => options.UseSqlServer(_connectionString));
            _Iservice = collection.BuildServiceProvider();
        }
        private static void Disposeservices()
        {
            if (_Iservice == null) return;
            if (_Iservice is IDisposable) ((IDisposable)_Iservice).Dispose();
        }
    }
}
