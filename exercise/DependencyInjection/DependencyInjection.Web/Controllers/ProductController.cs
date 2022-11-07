using DependencyInjection.Shared.Models;
using DependencyInjection.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
            => this.productService = productService;

        [HttpGet]
        public IEnumerable<ProductInfo> Get()
            => productService.GetAllProducts();

        [HttpGet("{id}")]
        public ProductInfo Get(string id)
            => productService.GetProductById(id);

        [HttpPost]
        public ProductInfo Post([FromBody] ProductInfo product)
            => productService.CreateNewProduct(product?.Name, product?.Price ?? 0);
    }
}
