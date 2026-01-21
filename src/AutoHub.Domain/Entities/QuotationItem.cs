namespace AutoHub.Domain.Entities
{
    public class QuotationItem
    {
        public int Id { get; set; }

        public int QuotationId { get; set; }
        public Quotation? Quotation { get; set; }

        public int? ItemId { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Rate { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public decimal Total { get; set; }
    }
}
