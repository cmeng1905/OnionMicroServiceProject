using OnionProject.Application.Repositories.Common;
using OnionProject.Application.Repositories.Product;
using OnionProject.Domain.Entities.Product;
using OnionProject.Persistence.Contexts;
using OnionProject.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<Urun>, IProductReadRepository
    {
        public ProductReadRepository(CmengDbContext context) : base(context)
        {
        }
    }
}
