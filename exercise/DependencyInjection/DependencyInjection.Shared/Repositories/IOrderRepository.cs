using DependencyInjection.Shared.Models;

namespace DependencyInjection.Shared.Repositories
{
    public interface IOrderRepository
    {
        void Create(OrderInfo newOrder);
        OrderInfo GetById(string orderId);
        void Update(OrderInfo orderInfo);
        IEnumerable<OrderInfo> GetAll();
    }
}
