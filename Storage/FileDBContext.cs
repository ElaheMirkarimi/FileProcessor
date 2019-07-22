using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class FileDBContext : DbContext 
    {
        //private const string connectionStrings = "Server=DESKTOP-RFQEHJ6;Database=FileProcessor;Trusted_Connection=True;MultipleActiveResultSets=true";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionStrings);
        //}

        public FileDBContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<Files> Files { get; set; }
    }
}
