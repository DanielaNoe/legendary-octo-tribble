using InvoiceApi.Data;
using InvoiceApi.Repositories;
using Microsoft.EntityFrameworkCore;
using InvoiceApi.Models;

namespace UnitTests.Invoices
{
    public class InvoiceRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _context;
        private readonly InvoiceRepository _repository;

        public InvoiceRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(_options);
            _repository = new InvoiceRepository(_context);
        }

        [Fact]
        public async Task DeleteInvoiceByIdAsync_ShouldSoftDeleteInvoice()
        {
            var invoiceId = Guid.NewGuid();
            var invoice = new Invoice { Id = invoiceId, InvoiceNumber = "INV-20250311-548", InvoiceDate = DateTime.Now, OrderId = Guid.NewGuid(), State = InvoiceState.CANCELLED, TotalPrice = 120.00, Deleted = false, DeletedAt = null };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            await _repository.DeleteInvoiceByIdAsync(invoiceId);

            var deletedInvoice = await _context.Invoices.FindAsync(invoiceId);
            Assert.NotNull(deletedInvoice);
            Assert.True(deletedInvoice.Deleted);
            Assert.NotNull(deletedInvoice.DeletedAt);
        }

        [Fact]
        public async Task DeleteInvoiceByIdAsync_ShouldThrowException_WhenDeletedInvoiceFound()
        {
            var invoiceId = Guid.NewGuid();
            var invoice = new Invoice { Id = invoiceId, InvoiceNumber = "INV-20250311-954", InvoiceDate = DateTime.Now, OrderId = Guid.NewGuid(), State = InvoiceState.CANCELLED, TotalPrice = 120.00, Deleted = true, DeletedAt = DateTime.Now };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            var exception = await Assert.ThrowsAsync<ApplicationException>(async () =>
                await _repository.DeleteInvoiceByIdAsync(invoiceId));

            Assert.Contains("Fehler beim Löschen der Rechnung!", exception.Message);
            Assert.Contains("Fehler beim Löschen der Rechnung: Rechnung nicht gefunden!", exception.InnerException?.Message);
        }

        [Fact]
        public async Task DeleteInvoiceByIdAsync_ShouldThrowException_WhenInvoiceNotFound()
        {
            var invoiceId = Guid.NewGuid();

            var exception = await Assert.ThrowsAsync<ApplicationException>(async () =>
                await _repository.DeleteInvoiceByIdAsync(invoiceId));

            Assert.Contains("Fehler beim Löschen der Rechnung!", exception.Message);
            Assert.Contains("Fehler beim Löschen der Rechnung: Rechnung nicht gefunden!", exception.InnerException?.Message);
        }
    }
}
