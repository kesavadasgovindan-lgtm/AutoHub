namespace AutoHub.Domain.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        // 🔗 inventory reference (nullable for labour)
        public int? ItemId { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Rate { get; set; }

        public int Quantity { get; set; }

        // ✅ critical for VAT logic
        public bool IsLabour { get; set; }

        public decimal Discount { get; set; }

        // calculated & stored
        public decimal GrossAmount { get; set; }

        public decimal VatAmount { get; set; }

        public decimal NetAmount { get; set; }
    }
}
