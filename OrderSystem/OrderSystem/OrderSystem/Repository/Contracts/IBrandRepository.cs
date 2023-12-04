using OrderSystem.Models;

namespace OrderSystem.Repository.Contracts
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllBrands();
        Task AddNewBrand(string brandName);
        Task RemoveBrand(string brandName);
    }
}
