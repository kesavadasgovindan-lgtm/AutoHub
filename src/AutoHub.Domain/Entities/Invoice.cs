using System;
namespace AutoHub.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }

        public string VehicleNumber { get; set; } = string.Empty;

        public string MakeModel { get; set; } = string.Empty;

        public string PaymentMode { get; set; } = "Cash";

        public decimal GrossAmount { get; set; }

        public decimal VatAmount { get; set; }

        public decimal NetAmount { get; set; }

        public bool IsCancelled { get; set; } = false;
    }
}
