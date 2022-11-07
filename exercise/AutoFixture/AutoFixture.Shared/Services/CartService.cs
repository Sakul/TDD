using AutoFixture.Shared.Models;

namespace AutoFixture.Shared.Services
{
    public class CartService : ICartService
    {
        private ILogger _logger;

        //public CartService(ILogger logger)
        //    => _logger = logger;

        public CartInfo AddProduct(CartInfo currentCart, params ProductInfo[] products)
        {
            _logger?.WriteLog("AddProduct");

            currentCart ??= new CartInfo
            {
                Id = Guid.NewGuid().ToString(),
                Products = new List<ProductInfo>(),
                CreatedDate = DateTime.Now,
            };
            currentCart.Products = currentCart.Products.Union(products).Distinct();
            currentCart.SubTotal = currentCart.Products.Sum(it => it.Price);
            currentCart.Taxes = Math.Ceiling(currentCart.SubTotal * 0.07);
            currentCart.Total = currentCart.SubTotal + currentCart.Taxes;
            return currentCart;
        }

        public CartInfo AddProduct(params ProductInfo[] products)
            => AddProduct(null, products);

        public CartInfo AddProduct(string id, string name, double price)
            => AddProduct(new ProductInfo { Id = id, Name = name, Price = price });
    }
}
