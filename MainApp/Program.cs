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
            Console.WriteLine("Please enter the path of the files: ");
            var filesPath = Console.ReadLine();
            var files = Directory.GetFiles(filesPath);
            _Iservice = DependencyContainer.RegisterServices().BuildServiceProvider();
            _Iservice.GetService<IService>().insertFile(files);
        }
    }
}
