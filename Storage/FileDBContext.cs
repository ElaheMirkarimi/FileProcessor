using Microsoft.EntityFrameworkCore;
using Service.Entity;

namespace Storage
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions option) : base(option) { }
        public DbSet<File> Files { get; set; }
    }
}
