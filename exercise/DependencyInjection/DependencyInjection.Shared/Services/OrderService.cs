using DependencyInjection.Shared.Models;
using DependencyInjection.Shared.Repositories;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Shared.Services
{
    public class OrderService
    {
        private readonly ILogger logger;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderService(ILogger logger,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            this.logger = logger;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public OrderInfo CreateNewOrder(string productId)
        {
            logger.LogInformation($"{nameof(CreateNewOrder)}, productId: {productId}");
            var selectedProduct = productRepository.GetById(productId);
            if (null == selectedProduct) return null;

            const double Tax = 0.07;
            var taxes = Math.Ceiling(selectedProduct.Price * Tax);
            var newOrder = new OrderInfo
            {
                Id = Guid.NewGuid().ToString().Substring(0, 8),
                CreatedDate = DateTime.Now,
                ProductInfo = selectedProduct,
                SubTotal = selectedProduct.Price,
                Taxes = taxes,
                Total = selectedProduct.Price + taxes,
            };
            orderRepository.Create(newOrder);
            return newOrder;
        }

        public OrderInfo GetOrderById(string orderId)
        {
            logger.LogInformation($"{nameof(GetOrderById)}, orderId: {orderId}");
            return orderRepository.GetById(orderId);
        }

        public IEnumerable<OrderInfo> GetAllOrders()
        {
            logger.LogInformation($"{nameof(GetAllOrders)}");
            return orderRepository.GetAll();
        }

        public OrderInfo CancelOrder(string orderId)
        {
            logger.LogInformation($"{nameof(CancelOrder)}, orderId: {orderId}");
            var selectedOrder = orderRepository.GetById(orderId);
            if (null == selectedOrder || selectedOrder.CancelledDate.HasValue) return null;

            selectedOrder.CancelledDate = DateTime.Now;
            orderRepository.Update(selectedOrder);
            return selectedOrder;
        }
    }
}
