using OrderSystem.Models;

namespace OrderSystem.Repository.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustommer(Customer customer);
        Task<List<Customer>> GetAll();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> GetCustomerByPhoneNumber(string phoneNumber);
    }
}
