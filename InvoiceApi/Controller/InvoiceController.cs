using Microsoft.AspNetCore.Mvc;
using InvoiceApi.ViewModels;
using InvoiceApi.Services;

namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceServiceInterface _invoiceService;

        public InvoiceController(InvoiceServiceInterface invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceViewModel>> GetInvoiceById(Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            return invoice == null ? NotFound() : Ok(invoice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceById(Guid id)
        {
            await _invoiceService.DeleteInvoiceByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(InvoiceViewModel invoice)
        {
            await _invoiceService.UpdateInvoiceAsync(invoice);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceViewModel invoice)
        {
            await _invoiceService.AddInvoiceAsync(invoice);
            return Ok();
        }
    }
}
