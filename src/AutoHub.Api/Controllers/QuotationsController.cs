using AutoHub.Api.Models.Quotation;
using AutoHub.Application.Services;
using AutoHub.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoHub.Api.Controllers
{
    [ApiController]
    [Route("api/quotations")]
    [Authorize]
    public class QuotationsController : ControllerBase
    {
        private readonly QuotationService _quotationService;

        public QuotationsController(QuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        // ✅ CREATE QUOTATION
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuotationRequest request)
        {
            var employeeId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var quotation = new Quotation
            {
                CustomerId = request.CustomerId,
                Date = request.Date,
                ValidTill = request.ValidTill,
                Remarks = request.Remarks,
                Status = "Draft",
                CreatedByEmployeeId = employeeId,
                QuotationNumber = $"QT-{DateTime.Now.Ticks}",
                Items = request.Items.Select(i => new QuotationItem
                {
                    Description = i.Description,
                    Rate = i.Rate,
                    Quantity = i.Quantity,
                    Discount = i.Discount,
                    Total = (i.Rate * i.Quantity) - i.Discount
                }).ToList()
            };

            quotation.SubTotal = quotation.Items.Sum(i => i.Rate * i.Quantity);
            quotation.Discount = quotation.Items.Sum(i => i.Discount);
            quotation.VatAmount = quotation.SubTotal * 0.05m;
            quotation.NetAmount = quotation.SubTotal - quotation.Discount + quotation.VatAmount;

            await _quotationService.CreateQuotationAsync(quotation);

            return Ok(quotation);
        }

        // ✅ GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotations = await _quotationService.GetAllAsync();
            return Ok(quotations);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var quotation = await _quotationService.GetByIdAsync(id);
            if (quotation == null)
                return NotFound();

            return Ok(quotation);
        }

        // ✅ APPROVE
        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var quotation = await _quotationService.GetByIdAsync(id);
            if (quotation == null)
                return NotFound();

            quotation.Status = "Approved";
            await _quotationService.UpdateAsync(quotation);

            return Ok("Quotation approved");
        }

        [HttpPost("{id}/convert")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConvertToInvoice(
       int id,
       [FromServices] InvoiceService invoiceService)
        {
            var quotation = await _quotationService.GetByIdAsync(id);

            if (quotation == null)
                return NotFound("Quotation not found");

            if (quotation.Status != "Approved")
                return BadRequest("Only approved quotations can be converted");

            var invoice = await invoiceService.CreateFromQuotationAsync(quotation);

            await _quotationService.MarkAsConvertedAsync(quotation);

            return Ok(new
            {
                message = "Quotation converted to invoice successfully",
                invoiceId = invoice.Id,
                invoiceNumber = invoice.InvoiceNumber
            });
        }



    }
}
