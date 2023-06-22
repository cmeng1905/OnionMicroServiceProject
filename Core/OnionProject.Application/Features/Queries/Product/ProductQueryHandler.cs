using MediatR;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.Product
{
    public class ProductQueryHandler : IRequestHandler<ProductQueryRequest, Response<ProductQueryResponse>>
    {
        private IProductService _productService;

        public ProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Response<ProductQueryResponse>> Handle(ProductQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _productService.GetProducts();
            return Response<ProductQueryResponse>.Success(new ProductQueryResponse
            {
                Products = response
            }, (int)HttpStatusCode.OK);
        }
    }
}
