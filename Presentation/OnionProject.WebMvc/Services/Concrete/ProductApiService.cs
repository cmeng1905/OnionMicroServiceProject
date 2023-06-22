using OnionProject.Application.Dtos.Product;
using OnionProject.Application.Dtos.Response;
using OnionProject.Application.Features.Queries.Product;
using OnionProject.WebMvc.Services.Abstractions;

namespace OnionProject.WebMvc.Services.Concrete
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _client;

        public ProductApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var productResult = await _client.GetFromJsonAsync<Response<ProductQueryResponse>>("Products");
            return productResult.Data.Products;
        }
    }
}
