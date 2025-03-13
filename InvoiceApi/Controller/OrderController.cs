using Microsoft.AspNetCore.Mvc;
using InvoiceApi.Services;
using InvoiceApi.ViewModels;

namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServiceInterface _orderService;

        public OrderController(OrderServiceInterface orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderViewModel>> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return order == null ? NotFound() : Ok(order);
        }
    }
}
