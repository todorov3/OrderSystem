namespace OrderSystem.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
