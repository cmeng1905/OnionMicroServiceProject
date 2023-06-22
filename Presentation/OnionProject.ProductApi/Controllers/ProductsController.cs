using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.ControllerBases;
using OnionProject.Application.Features.Queries.Product;
using System.Data;

namespace OnionProject.ProductApi.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var user = User.Identity.Name;
            var products =await _mediator.Send(new ProductQueryRequest
            {

            });
            return CreateActionResultInstance(products);
        }
    }
}
