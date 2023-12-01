namespace OrderSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public int PriceIncreasePercentage { get; set; }
        public bool IsDeleted { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
    }
}
