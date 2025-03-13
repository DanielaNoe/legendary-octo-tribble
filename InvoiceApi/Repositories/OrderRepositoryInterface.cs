using InvoiceApi.Models;

namespace InvoiceApi.Repositories
{
    public interface OrderRepositoryInterface
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order?> GetOrderByIdAsync(Guid id);
    }
}
