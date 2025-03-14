using InvoiceApi.Services;
using InvoiceApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests.Invoices
{
    public class InvoiceControllerTests
    {
        private readonly Mock<InvoiceServiceInterface> _mockInvoiceService;
        private readonly InvoiceController _controller;

        public InvoiceControllerTests()
        {
            _mockInvoiceService = new Mock<InvoiceServiceInterface>();
            _controller = new InvoiceController(_mockInvoiceService.Object);
        }

        [Fact]
        public async Task DeleteInvoiceByIdTest_ShouldReturnStatusCodeOK()
        {
            var invoiceId = Guid.NewGuid();
            _mockInvoiceService.Setup(service => service.DeleteInvoiceByIdAsync(invoiceId))
                .Returns(Task.CompletedTask);

            var result = await _controller.DeleteInvoiceById(invoiceId);

            var actionResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, actionResult.StatusCode);
            _mockInvoiceService.Verify(service => service.DeleteInvoiceByIdAsync(invoiceId), Times.Once);
        }
    }
}
