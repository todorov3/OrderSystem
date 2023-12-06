using Dapper;
using OrderSystem.Data;
using OrderSystem.Exceptions;
using OrderSystem.Models;
using System.Data;

namespace OrderSystem.Repository.Contracts
{
    public interface IOrderRepository
    {
        //Task<Order> CreateOrder();
        //Task<List<Order>> GetAllOrdersByDate(DateTime date);

        //Task<List<Order>> GetAllOrdersByCustomerId(int customerId);

        Task<int> CreateOrder();

        Task AddProductToOrder(int orderId, int productId);

        Task<List<Order>> GetAllOrdes();

        Task<Order> GetOrderById(int id);

        Task DeleteOrder(int id);
    }
}
