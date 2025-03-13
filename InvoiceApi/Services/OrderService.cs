using InvoiceApi.Helper;
using InvoiceApi.Repositories;
using InvoiceApi.ViewModels;

namespace InvoiceApi.Services
{
    public class OrderService : OrderServiceInterface
    {
        private readonly OrderRepositoryInterface _orderRepository;
        private readonly OrderMapper _orderMapper;

        public OrderService(OrderRepositoryInterface orderRepository, OrderMapper orderMapper)
        {
            _orderRepository = orderRepository;
            _orderMapper = orderMapper;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();

            return orders.Select(o => _orderMapper.MapOrderToOrderViewModel(o)).ToList();
        }

        public async Task<OrderViewModel?> GetOrderByIdAsync(Guid orderId)
        {
            var o = await _orderRepository.GetOrderByIdAsync(orderId);

            return o == null ? null : _orderMapper.MapOrderToOrderViewModel(o);
        }
    }
}
