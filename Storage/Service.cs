using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class mainService : IService
    {
        private FileDBContext _context;
        private DbSet<Files> _dbSet;
        public mainService(FileDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Files>();
        }
        public async Task insertFile(string[] files)
        {
            try
            {
                Parallel.ForEach(files, file =>
                {
                    file.Trim();
                    var fileName = Path.GetFileName(file);
                    var fileSection = fileName.Split('.');
                    Files fileData = new Files
                    {
                        FileName = fileName,
                        FilePath = file,
                        Month = Convert.ToInt16(fileSection[0].Substring(4, 2)),
                        Guid = fileSection[1],
                        Version = Convert.ToInt16(fileSection[2].Substring(1, 2))
                    };
                    _dbSet.AddRange(fileData);
                });
                    await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
