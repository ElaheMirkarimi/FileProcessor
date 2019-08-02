using Microsoft.Extensions.Logging;
using Service.Entity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage
{
    public class FileStore : IFileStore
    {
        private FileDbContext _context;
        private readonly ILogger<FileStore> _logger;

        public FileStore(FileDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<FileStore>();
        }

        public async Task SaveDataBatchAsync(List<File> files)
        {
            try
            {
                _context.Set<File>().AddRange(files);
                await _context.SaveChangesAsync();
                _context.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
