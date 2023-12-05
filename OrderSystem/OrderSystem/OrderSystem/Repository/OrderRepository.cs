using Dapper;
using OrderSystem.Data;
using OrderSystem.Exceptions;
using OrderSystem.Models;
using OrderSystem.Repository.Contracts;
using System.Data;

namespace OrderSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _dapperContext;

        public OrderRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateOrder()
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("OrdersDate", DateTime.Now, DbType.DateTime);

            using var connection = _dapperContext.CreateConnection();
            {
                var result = await connection.QuerySingleOrDefaultAsync<int>(
                    "spOrderCreate",
                    parameters,
                    commandType:
                    CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task AddProductToOrder(int orderId, int productId)
        {

        }

        public async Task<List<Order>> GetAllOrdes()
        {
            var connection = _dapperContext.CreateConnection();

            return (await connection.QueryAsync<Order>(
                "spOrdersGetAll",
                commandType:
                CommandType.StoredProcedure))
                .ToList();
        }

        public async Task<Order> GetOrderById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                var order = await connection.QuerySingleOrDefaultAsync<Order>(
                    "spOrederGetById",
                    commandType:
                    CommandType.StoredProcedure);

                return order ?? throw new EntityNotFoundException($"Order with id {id} not found");
            }
        }
    }
}
