using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class FileDBContext : DbContext 
    {
        public FileDBContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<FilesEntity> Files { get; set; }
    }
}
