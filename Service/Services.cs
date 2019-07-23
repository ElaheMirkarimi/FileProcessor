using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage;

namespace Service
{
    public class Services : IService
    {
        public IServiceProvider _Iservice;
        private IStore _fSstore;
        public Services(IStore fStore)
        {
            _fSstore = fStore;
        }
        public void insertFile(string[] files)
        {
            Parallel.ForEach(files, file =>
            {
                file.Trim();
                var fileName = Path.GetFileName(file);
                var fileSection = fileName.Split('.');
                FilesEntity fileData = new FilesEntity
                {
                    FileName = fileName,
                    FilePath = file,
                    Month = Convert.ToInt16(fileSection[0].Substring(4, 2)),
                    Guid = fileSection[1],
                    Version = Convert.ToInt16(fileSection[2].Substring(1, 2))
                };
                Task.Run(() => _fSstore.saveData(fileData));
            });
        }
        public void RegisterServices()
        {
            string _connectionString = "Server=DESKTOP-RFQEHJ6;Database=FileProcessor;Trusted_Connection=True;MultipleActiveResultSets=true";
            var collection = new ServiceCollection()
                .AddScoped<IService, Services>()
                .AddScoped<IStore, Store>();
            collection.AddDbContext<FileDBContext>(options => options.UseSqlServer(_connectionString));
            _Iservice = collection.BuildServiceProvider();
        }
        public void Disposeservices()
        {
            if (_Iservice == null) return;
            if (_Iservice is IDisposable) ((IDisposable)_Iservice).Dispose();
        }
    }
}
