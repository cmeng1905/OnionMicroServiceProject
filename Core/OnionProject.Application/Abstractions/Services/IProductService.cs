using OnionProject.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Abstractions.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
    }
}
