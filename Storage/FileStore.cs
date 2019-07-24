using Microsoft.Extensions.Logging;
using Infra.Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage
{
    public class FileStore : IFileStore
    {
        private IFileDbContextBuilder _contextBuilder;
        private readonly ILogger<FileStore> _logger;

        public FileStore(IFileDbContextBuilder contextBuilder, ILoggerFactory loggerFactory)
        {
            _contextBuilder = contextBuilder;
            _logger = loggerFactory.CreateLogger<FileStore>();
        }
        public async Task SaveDataAsync(File file)
        {
            try
            {
                using (var context = _contextBuilder.Build())
                {
                    context.Set<File>().Add(file);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task SaveDataBatchAsync(List<File> files)
        {
            try
            {
                using (var context = _contextBuilder.Build())
                {
                    context.Set<File>().AddRange(files);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
