using AutoHub.Application.Services;
using AutoHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Api.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _service;

        public InvoicesController(InvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
        {
            await _service.CreateInvoiceAsync(request.Invoice, request.Items);
            return Ok();
        }
    }

    public class InvoiceRequest
    {
        public Invoice Invoice { get; set; } = new();
        public List<InvoiceItem> Items { get; set; } = new();
    }
}
