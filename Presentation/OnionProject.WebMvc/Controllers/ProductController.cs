using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionProject.WebMvc.Models.Product;
using OnionProject.WebMvc.Services.Abstractions;

namespace OnionProject.WebMvc.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class ProductController : Controller
    {
        IProductApiService _productApiService;

        public ProductController(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetProducts();
            var model = new ProductViewModel
            {
                Products=products
            };
            return View(model);
        }
    }
}
