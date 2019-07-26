using Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Service
{
    public class FileService : IFileService
    {
        //private IFileStore _store;
        private IServiceProvider _serviceProvider;
        public FileService(/*IFileStore store,*/ IServiceProvider serviceProvider)
        {
            //_store = store;
            _serviceProvider = serviceProvider;
        }

        public async Task InsertFilesBatchAsync(string[] files)
        {
            var fileList = new List<Entity.File>();
            Parallel.ForEach(files, filePath =>
            {
                fileList.Add(CreateEntity(filePath));
            });
            //await _store.SaveDataBatchAsync(fileList);
            using (var scope = _serviceProvider.CreateScope())
            {
                await scope.ServiceProvider.GetService<IFileStore>().SaveDataBatchAsync(fileList);
            }
        }

        private Entity.File CreateEntity(string filePath)
        {
            filePath.Trim();
            var fileName = Path.GetFileName(filePath);
            var fileSection = fileName.Split('.');
            return new Entity.File
            {
                FileName = fileName,
                FilePath = filePath,
                Month = Convert.ToInt16(fileSection[0].Substring(4, 2)),
                Guid = fileSection[1],
                Version = Convert.ToInt16(fileSection[2].Substring(1, 2))
            };
        }
    }
}
