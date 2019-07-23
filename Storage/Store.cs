using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Store : IStore
    {
        private FileDBContext _context;
        private DbSet<FilesEntity> _dbSet;
        public Store(FileDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<FilesEntity>();
        }
        public async Task saveData(FilesEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
