using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace MainApp
{
    class Program
    {
        static void Main()
        {
            //Services._Iservice.GetService<IService>();
            //var fileService = Services._Iservice;
            //Services.RegisterServices();
            Console.WriteLine("Please enter the path of the files: ");
            var filesPath = Console.ReadLine();
            var files = Directory.GetFiles(filesPath);
            //Service.Services.insertFile(files);
            //fileService.Disposeservices();
        }
    }
}
