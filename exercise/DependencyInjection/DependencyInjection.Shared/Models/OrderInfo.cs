namespace DependencyInjection.Shared.Models
{
    public class OrderInfo
    {
        public string Id { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public double SubTotal { get; set; }
        public double Taxes { get; set; }
        public double Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CancelledDate { get; set; }
    }
}
