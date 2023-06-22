using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnionProject.Application.Repositories.Common;
using OnionProject.Domain.Entities.Common;
using OnionProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Repositories.Common
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly CmengDbContext _context;
        public ReadRepository(CmengDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
    }
}
