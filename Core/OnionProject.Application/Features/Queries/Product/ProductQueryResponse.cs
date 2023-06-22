using OnionProject.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.Product
{
    public class ProductQueryResponse
    {
        public List<ProductDto> Products { get; set;}
    }
}
