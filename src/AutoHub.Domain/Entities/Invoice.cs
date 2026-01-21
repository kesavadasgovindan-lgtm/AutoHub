using System;
using System.Collections.Generic;

namespace AutoHub.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal VatAmount { get; set; }

        public decimal NetAmount { get; set; }

        public int? QuotationId { get; set; }

        public string Status { get; set; } = "Active";

        public List<InvoiceItem> Items { get; set; } = new();
    }
}
