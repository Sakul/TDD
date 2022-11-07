using DependencyInjection.Shared.Models;
using DependencyInjection.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
            => this.orderService = orderService;

        [HttpGet]
        public IEnumerable<OrderInfo> Get()
            => orderService.GetAllOrders();

        [HttpGet("{id}")]
        public OrderInfo Get(string id)
            => orderService.GetOrderById(id);

        [HttpPost("{productId}")]
        public OrderInfo Post(string productId)
            => orderService.CreateNewOrder(productId);

        [HttpPut("{id}")]
        public OrderInfo Put(string id)
            => orderService.CancelOrder(id);
    }
}
