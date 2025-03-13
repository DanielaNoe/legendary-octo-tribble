using InvoiceApi.Models;
using InvoiceApi.ViewModels;

namespace InvoiceApi.Repositories
{
    public interface InvoiceRepositoryInterface
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();

        Task<Invoice?> GetInvoiceByIdAsync(Guid id);

        Task DeleteInvoiceByIdAsync(Guid invoiceId);

        Task UpdateInvoiceAsync(InvoiceViewModel invoice);

        Task AddInvoiceAsync(InvoiceViewModel invoice);
    }
}
