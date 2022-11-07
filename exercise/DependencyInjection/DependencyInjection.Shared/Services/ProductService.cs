using DependencyInjection.Shared.Models;
using DependencyInjection.Shared.Repositories;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Shared.Services
{
    public class ProductService
    {
        private readonly ILogger logger;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public ProductService(ILogger logger,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            this.logger = logger;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public ProductInfo CreateNewProduct(string name, double price)
        {
            logger.LogInformation($"{nameof(CreateNewProduct)}, name: {name}, price: {price}");
            var areArgumentsValid = false == string.IsNullOrWhiteSpace(name) && price >= 0;
            if (false == areArgumentsValid) return null;

            var newProduct = new ProductInfo
            {
                Id = Guid.NewGuid().ToString().Substring(0, 8),
                Name = name,
                Price = price,
                CreatedDate = DateTime.Now,
            };
            productRepository.Create(newProduct);
            return newProduct;
        }

        public ProductInfo GetProductById(string productId)
        {
            logger.LogInformation($"{nameof(GetProductById)}, orderId: {productId}");
            return productRepository.GetById(productId);
        }

        public IEnumerable<ProductInfo> GetAllProducts()
        {
            logger.LogInformation($"{nameof(GetAllProducts)}");
            return productRepository.GetAll();
        }
    }
}
