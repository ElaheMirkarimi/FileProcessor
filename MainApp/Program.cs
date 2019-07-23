using System;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace MainApp
{
    class Program
    {
        public static IServiceProvider _Iservice;
        static void Main()
        {
            //var serviceProvider = new IServiceCollection();
            Console.WriteLine("Please enter the path of the files: ");
            var filesPath = Console.ReadLine();
            var files = Directory.GetFiles(filesPath);
            _Iservice = DependencyContainer.RegisterServices().BuildServiceProvider();
            _Iservice.GetService<IService>().insertFile(files);
            //Service.Services.insertFile(files);
            //fileService.Disposeservices();
        }
        



        //public IServiceProvider _Iservice;
        //public void RegisterServices()
        //{
        //    string _connectionString = "Server=DESKTOP-RFQEHJ6;Database=FileProcessor;Trusted_Connection=True;MultipleActiveResultSets=true";
        //    var collection = new ServiceCollection()
        //        .AddScoped<IService, Services>()
        //        .AddScoped<IStore, Store>();
        //    collection.AddDbContext<FileDBContext>(options => options.UseSqlServer(_connectionString));
        //    _Iservice = collection.BuildServiceProvider();
        //    //Services._Iservice.GetService<IService>();
        //}
        //public void Disposeservices()
        //{
        //    if (_Iservice == null) return;
        //    if (_Iservice is IDisposable) ((IDisposable)_Iservice).Dispose();
        //}







    }
}
