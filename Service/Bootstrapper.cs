using System;
using System.IO;
using System.Threading.Tasks;

namespace Service
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly IFileService _service;
        public Bootstrapper(IFileService service) => _service = service;

        public async Task Run()
        {
            Console.WriteLine("Please enter the path of the files: ");
            var filesPath = "f:\\test";// Console.ReadLine();
            var files = Directory.GetFiles(filesPath);
            await _service.InsertFilesBatchAsync(files);
            Console.WriteLine("Execution completed successfully.");
        }
    }
}
