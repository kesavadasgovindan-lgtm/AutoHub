using System;
using System.Collections.Generic;

namespace AutoHub.Domain.Entities
{
    public class Quotation
    {
        public int Id { get; set; }

        public string QuotationNumber { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime Date { get; set; }
        public DateTime ValidTill { get; set; }

        public string Status { get; set; } = "Draft";

        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal NetAmount { get; set; }

        public string? Remarks { get; set; }

        public int CreatedByEmployeeId { get; set; }
        public Employee? CreatedByEmployee { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<QuotationItem> Items { get; set; } = new List<QuotationItem>();
    }
}
