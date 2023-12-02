using OrderSystem.Models;

namespace OrderSystem.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAll();
    }
}
