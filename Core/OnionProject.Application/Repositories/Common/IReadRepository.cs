using OnionProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Repositories.Common
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T,bool>> method,bool tracking = true);
    }
}
