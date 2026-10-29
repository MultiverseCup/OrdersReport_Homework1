namespace OrdersReport.Domain.Entities
{
    public class Order
    {
        public long ClientId { get; set; }
        public long OrderId { get; set; }
        public required string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public float ItemPrice { get; set; }
    }
}
