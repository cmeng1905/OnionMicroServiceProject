using OnionProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Repositories.Common
{
    public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
    {
        Task<bool> AddAsync(T Model);
        bool Update(T Model);
        bool Remove(T model);
        Task<int> SaveAsync();
    }
}
