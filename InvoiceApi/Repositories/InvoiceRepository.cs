using InvoiceApi.Data;
using InvoiceApi.Models;
using InvoiceApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.Repositories
{
    public class InvoiceRepository : InvoiceRepositoryInterface
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.Order)
                    .ThenInclude(o => o.Positions
                        .Where(i => !i.Deleted))
                        .ThenInclude(p => p.Article)
                .Include(i => i.Order)
                    .ThenInclude(o => o.Customer)
                .Include(i => i.Order)
                    .ThenInclude(o => o.BillingAddress)
                .Include(i => i.Order)
                    .ThenInclude(o => o.DeliveryAddress)
                .Where(i => i.Order != null && i.Order.Positions != null && i.Order.Customer != null && !i.Deleted)
                .ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(Guid id)
        {
            return await _context.Invoices
                .Include(i => i.Order)
                    .ThenInclude(o => o.Positions
                        .Where(i => !i.Deleted))
                        .ThenInclude(p => p.Article)
                .Include(i => i.Order)
                    .ThenInclude(o => o.Customer)
                .Include(i => i.Order)
                    .ThenInclude(o => o.BillingAddress)
                .Include(i => i.Order)
                    .ThenInclude(o => o.DeliveryAddress)
                .Where(i => i.Order != null && i.Order.Positions != null && i.Id == id && !i.Deleted)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteInvoiceByIdAsync(Guid id)
        {
            try
            {
                var invoiceDB = await _context.Invoices
                    .Where(i => i.Id == id && !i.Deleted)
                    .FirstOrDefaultAsync() ?? throw new ApplicationException("Fehler beim Löschen der Rechnung: Rechnung nicht gefunden!");

                invoiceDB.Deleted = true;
                invoiceDB.DeletedAt = DateTime.Now;

                _context.Entry(invoiceDB).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch (Exception e) {
                throw new ApplicationException("Fehler beim Löschen der Rechnung!", e);
            }
        }

        public async Task UpdateInvoiceAsync(InvoiceViewModel invoice)
        {
            try
            {
                var invoiceDB = await _context.Invoices
                    .Where(i => i.Id == invoice.Id && !i.Deleted)
                    .FirstOrDefaultAsync() ?? throw new ApplicationException("Fehler beim Bearbeiten der Rechnung: Rechnung nicht gefunden!");

                if (invoiceDB.State == InvoiceState.CANCELLED)
                {
                    throw new ApplicationException("Fehler beim Bearbeiten der Rechnung: Rechnung mit Status CANCELLED kann nicht bearbeitet werden!");
                }

                invoiceDB.State = (Models.InvoiceState)invoice.State;

                _context.Entry(invoiceDB).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Fehler beim Bearbeiten der Rechnung!", e);
            }
        }

        public async Task AddInvoiceAsync(InvoiceViewModel invoice)
        {
            try
            {
                var orderDB = await _context.Orders
                    .Where(o => o.Id == invoice.Order.Id && !o.Deleted)
                    .FirstOrDefaultAsync() ?? throw new ApplicationException("Fehler beim Hinzufügen der Rechnung: Bestellung nicht gefunden!");

                var invoiceNumber = orderDB.OrderNumber;
                invoiceNumber = invoiceNumber.Replace("ORD", "INV");

                var invoiceDB = await _context.Invoices
                    .Where(i => i.InvoiceNumber == invoiceNumber)
                    .FirstOrDefaultAsync();

                bool newInvoiceIsAddable = true;

                if (invoiceDB != null)
                {
                    var index = 1;

                    for (int i = 1; i < 1000; i++)
                    {
                        index = i;
                        var invoiceNumberTest = invoiceNumber + "-" + i;

                        var lastExistingInvoiceDB = await _context.Invoices
                            .Where(i => i.InvoiceNumber == invoiceNumberTest)
                            .FirstOrDefaultAsync();

                        if (lastExistingInvoiceDB == null)
                        {
                            break;
                        }
                        else
                        {
                            if (!lastExistingInvoiceDB.Deleted && lastExistingInvoiceDB.State != InvoiceState.CANCELLED)
                            {
                                newInvoiceIsAddable = false;
                            }
                        }
                    }

                    invoiceNumber += "-";
                    invoiceNumber += index;
                }                

                if (!newInvoiceIsAddable)
                {
                    throw new ApplicationException("Fehler beim Hinzufügen der Rechnung: Es kann nur eine Rechnung (außer Status CANCELLED) pro Bestellung geben!");
                }

                var newInvoice = new Invoice();
                newInvoice.Id = Guid.NewGuid();
                newInvoice.InvoiceNumber = invoiceNumber;
                newInvoice.InvoiceDate = DateTime.Now;
                newInvoice.State = InvoiceState.CREATED;
                newInvoice.TotalPrice = orderDB.TotalPrice;
                newInvoice.Deleted = false;
                newInvoice.Order = orderDB;

                _context.Invoices.Add(newInvoice);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Fehler beim Hinzufügen der Rechnung!", e);
            }
        }
    }
}
