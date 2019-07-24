using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infra.Data;

namespace Storage
{
    public class FileDbContextBuilder : IFileDbContextBuilder
    {
        private readonly string _connectionString;

        public FileDbContextBuilder(IConfigurationRoot configuration)
        {
            _connectionString = configuration.GetConnectionString("fileDb");
        }

        public DbContext Build()
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<FileDbContext>()
                .UseSqlServer(_connectionString);
            return new FileDbContext(dbContextOptionBuilder.Options);
        }
    }
}
