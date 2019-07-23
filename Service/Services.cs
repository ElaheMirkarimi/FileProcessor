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
        private IStore _fStore;
        public Services(IStore fStore)
        {
            _fStore = fStore;
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
                Task.Run(() => _fStore.saveData(fileData));
            });
        }
    }
}
