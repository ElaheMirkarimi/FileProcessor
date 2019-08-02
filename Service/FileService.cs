using Service.Interface;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class FileService : IFileService
    {
        private readonly IFileStore _fileStore;


        public FileService(IFileStore fileStore)
        {

            _fileStore = fileStore;
        }

        public async Task InsertFilesBatchAsync(string[] files)
        {
            var fileList = new ConcurrentBag<Entity.File>();

            Parallel.ForEach(files, filePath =>
            {
                fileList.Add(CreateEntity(filePath));
            });

            await _fileStore.SaveDataBatchAsync(fileList.ToList());
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
