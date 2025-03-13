using InvoiceApi.ViewModels;

namespace InvoiceApi.Services
{
    public interface OrderServiceInterface
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();

        Task<OrderViewModel?> GetOrderByIdAsync(Guid orderId);
    }
}
