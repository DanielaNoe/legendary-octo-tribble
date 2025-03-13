using InvoiceApi.Data;
using InvoiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.Repositories
{
    public class OrderRepository : OrderRepositoryInterface
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Invoices
                    .Where(i => !i.Deleted))
                .Include(o => o.Customer)
                .Include(o => o.BillingAddress)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.Positions
                    .Where(i => !i.Deleted))
                    .ThenInclude(p => p.Article)
                .Where(o => !o.Deleted)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.BillingAddress)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.Positions
                    .Where(i => !i.Deleted))
                    .ThenInclude(p => p.Article)
                .Where(o => !o.Deleted && o.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
