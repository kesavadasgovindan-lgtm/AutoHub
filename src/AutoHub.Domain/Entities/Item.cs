namespace AutoHub.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        // Part code
        public string Code { get; set; } = string.Empty;

        // Description
        public string Name { get; set; } = string.Empty;

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public int Stock { get; set; }

        public bool VatApplicable { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}
