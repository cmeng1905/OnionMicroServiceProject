using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionProject.Application.Repositories.Common;
using OnionProject.Domain.Entities.Common;
using OnionProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Repositories.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private CmengDbContext _context;
        public WriteRepository(CmengDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
