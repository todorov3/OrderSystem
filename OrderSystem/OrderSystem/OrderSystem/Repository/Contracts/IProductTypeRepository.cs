using OrderSystem.Models;

namespace OrderSystem.Repository.Contracts
{
    public interface IProductTypeRepository
    {
        Task<List<ProductType>> GetAllTypes();
        Task AddNewType(string typeName);
        Task RemoveType(string typeName);
    }
}
