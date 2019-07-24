using Infra.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Service
{
    public class FileService : IFileService
    {
        private IFileStore _store;
        public FileService(IFileStore store) => _store = store;

        public async Task InsertFilesAsync(string[] files)
        {
            var tasks = new List<Task>();
            foreach (var filePath in files)
            {
                var entity = CreaateEntity(filePath);
                var task = _store.SaveDataAsync(entity);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }

        public async Task InsertFilesBatchAsync(string[] files)
        {
            var fileList = new List<Entity.File>();
            foreach (var filePath in files)
            {
                fileList.Add(CreaateEntity(filePath));
            }
            await _store.SaveDataBatchAsync(fileList);
        }

        private Entity.File CreaateEntity(string filePath)
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
