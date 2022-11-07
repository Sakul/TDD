using AutoFixture.Shared.Models;

namespace AutoFixture.Shared.Services
{
    public interface ICartService
    {
        CartInfo AddProduct(params ProductInfo[] products);
        CartInfo AddProduct(string id, string name, double price);
        CartInfo AddProduct(CartInfo currentCart, params ProductInfo[] products);
    }
}
