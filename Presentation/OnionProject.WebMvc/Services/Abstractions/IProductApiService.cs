using OnionProject.Application.Dtos.Product;

namespace OnionProject.WebMvc.Services.Abstractions
{
    public interface IProductApiService
    {
        Task<List<ProductDto>> GetProducts();
    }
}
