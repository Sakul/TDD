namespace AutoFixture.Shared.Models
{
    public class CartInfo
    {
        public string Id { get; set; }
        public IEnumerable<ProductInfo> Products { get; set; }
        public double SubTotal { get; set; }
        public double Taxes { get; set; }
        public double Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CancelledDate { get; set; }
    }
}
