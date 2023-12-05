namespace OrderSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrdersDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsFinalized { get; set; }
        public bool IsDeleted { get; set; }
        public Customer Customer { get; set; }
    }
}
