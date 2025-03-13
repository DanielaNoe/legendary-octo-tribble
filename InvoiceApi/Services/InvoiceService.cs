using InvoiceApi.Helper;
using InvoiceApi.Repositories;
using InvoiceApi.ViewModels;

namespace InvoiceApi.Services
{
    public class InvoiceService : InvoiceServiceInterface
    {
        private readonly InvoiceRepositoryInterface _invoiceRepository;
        private readonly OrderMapper _orderMapper;

        public InvoiceService(InvoiceRepositoryInterface invoiceRepository, OrderMapper orderMapper)
        {
            _invoiceRepository = invoiceRepository;
            _orderMapper = orderMapper;
        }

        public async Task<IEnumerable<InvoiceViewModel>> GetAllInvoicesAsync()
        {

            var invoices = await _invoiceRepository.GetAllInvoicesAsync();

            return invoices.Select(i => new InvoiceViewModel
            {
                Id = i.Id,
                InvoiceNumber = i.InvoiceNumber,
                InvoiceDate = i.InvoiceDate,
                State = i.State,
                TotalPrice = i.TotalPrice,
                Order = _orderMapper.MapOrderToOrderViewModel(i.Order)
            }).ToList();
        }

        public async Task<InvoiceViewModel?> GetInvoiceByIdAsync(Guid id)
        {
            var i = await _invoiceRepository.GetInvoiceByIdAsync(id);

            return i == null ? null : new InvoiceViewModel
            {
                Id = i.Id,
                InvoiceNumber = i.InvoiceNumber,
                InvoiceDate = i.InvoiceDate,
                TotalPrice = i.TotalPrice,
                State = i.State,
                Order = _orderMapper.MapOrderToOrderViewModel(i.Order)
            };
        }

        public async Task DeleteInvoiceByIdAsync(Guid invoiceId)
        {
            await _invoiceRepository.DeleteInvoiceByIdAsync(invoiceId);
        }

        public async Task UpdateInvoiceAsync(InvoiceViewModel invoice)
        {
            await _invoiceRepository.UpdateInvoiceAsync(invoice);
        }

        public async Task AddInvoiceAsync(InvoiceViewModel invoice)
        {
            await _invoiceRepository.AddInvoiceAsync(invoice);
        }
    }
}
