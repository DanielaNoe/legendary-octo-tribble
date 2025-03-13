using InvoiceApi.ViewModels;

namespace InvoiceApi.Services
{
    public interface InvoiceServiceInterface
    {
        Task<IEnumerable<InvoiceViewModel>> GetAllInvoicesAsync();

        Task<InvoiceViewModel?> GetInvoiceByIdAsync(Guid id);

        Task DeleteInvoiceByIdAsync(Guid invoiceId);

        Task UpdateInvoiceAsync(InvoiceViewModel invoice);

        Task AddInvoiceAsync(InvoiceViewModel invoice);
    }
}
