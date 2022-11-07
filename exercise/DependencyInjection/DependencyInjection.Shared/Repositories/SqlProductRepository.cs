using DependencyInjection.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DependencyInjection.Shared.Repositories
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly ILogger logger;
        private readonly ShoppingContext shoppingContext;

        public SqlProductRepository(ILogger logger,
            ShoppingContext shoppingContext)
        {
            this.logger = logger;
            this.shoppingContext = shoppingContext;
        }

        public void Create(ProductInfo newProduct)
        {
            logger.LogInformation($"{nameof(Create)}, data: {JsonSerializer.Serialize(newProduct)}");
            shoppingContext.Products.Add(newProduct);
            shoppingContext.SaveChanges();
        }

        public IEnumerable<ProductInfo> GetAll()
        {
            logger.LogInformation($"{nameof(GetAll)}");
            return shoppingContext.Products;
        }

        public ProductInfo GetById(string productId)
        {
            logger.LogInformation($"{nameof(GetById)}, orderId: {productId}");
            return shoppingContext.Products.FirstOrDefault(it => it.Id == productId);
        }
    }
}
