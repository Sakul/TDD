using DependencyInjection.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DependencyInjection.Shared.Repositories
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly ILogger logger;
        private readonly ShoppingContext shoppingContext;

        public SqlOrderRepository(ILogger logger,
            ShoppingContext shoppingContext)
        {
            this.logger = logger;
            this.shoppingContext = shoppingContext;
        }

        public void Create(OrderInfo newOrder)
        {
            logger.LogInformation($"{nameof(Create)}, data: {JsonSerializer.Serialize(newOrder)}");
            shoppingContext.Orders.Add(newOrder);
            shoppingContext.SaveChanges();
        }

        public IEnumerable<OrderInfo> GetAll()
        {
            logger.LogInformation($"{nameof(GetAll)}");
            return shoppingContext.Orders;
        }

        public OrderInfo GetById(string orderId)
        {
            logger.LogInformation($"{nameof(GetById)}, orderId: {orderId}");
            return shoppingContext.Orders.FirstOrDefault(it => it.Id == orderId);
        }

        public void Update(OrderInfo orderInfo)
        {
            logger.LogInformation($"{nameof(Update)}, data: {JsonSerializer.Serialize(orderInfo)}");
            if (null == GetById(orderInfo.Id))
            {
                return;
            }

            shoppingContext.SaveChanges();
        }
    }
}
