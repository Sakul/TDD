using DependencyInjection.Shared.Models;

namespace DependencyInjection.Shared.Repositories
{
    public interface IProductRepository
    {
        void Create(ProductInfo newProduct);
        ProductInfo GetById(string productId);
        IEnumerable<ProductInfo> GetAll();
    }
}
