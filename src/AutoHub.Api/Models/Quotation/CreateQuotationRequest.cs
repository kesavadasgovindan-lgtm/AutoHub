using System.Collections.Generic;

namespace AutoHub.Api.Models.Quotation
{
    public class CreateQuotationRequest
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidTill { get; set; }
        public string? Remarks { get; set; }

        public List<CreateQuotationItemRequest> Items { get; set; } = new();
    }

    public class CreateQuotationItemRequest
    {
        public string Description { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
