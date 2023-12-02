using OrderSystem.Models;

namespace OrderSystem.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder();
        Task<List<Order>> GetAllOrdersByDate(DateTime date);
        Task<List<Order>> GetAllOrdersByCustomerId(int customerId);
    }
}
