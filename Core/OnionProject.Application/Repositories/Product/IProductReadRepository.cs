using OnionProject.Application.Repositories.Common;
using OnionProject.Domain.Entities.Common;
using OnionProject.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Repositories.Product
{
    public interface IProductReadRepository:IReadRepository<Urun>
    {
    }
}
