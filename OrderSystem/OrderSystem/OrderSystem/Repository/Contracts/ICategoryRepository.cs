using OrderSystem.Models;

namespace OrderSystem.Repository.Contracts
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task AddNewCategory(string categoryName);
        Task RemoveCategory(string categoryName);
    }
}
