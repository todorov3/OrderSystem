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
        private readonly IProductRepository _productRepository;

        public OrderRepository(DapperContext dapperContext, IProductRepository productRepository)
        {
            _dapperContext = dapperContext;
            _productRepository = productRepository;
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
            var existingOrder = await GetOrderById(orderId);
            if (existingOrder == null || existingOrder.IsDeleted == true)
            {
                throw new EntityNotFoundException($"Order with id {orderId} not found.");
            }

            var productToAdd = _productRepository.GetProductById(productId);
            if (productToAdd == null || productToAdd.IsDeleted == true)
            {
                throw new EntityNotFoundException($"Product with id {productId} not found.");
            }

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("OrderId", orderId, DbType.Int32);
            parameters.Add("ProductId", productId, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                    "spProductAddToOrder",
                    parameters,
                    commandType:
                    CommandType.StoredProcedure);
            }
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

        public async Task DeleteOrder(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                    "spOrderDelete",
                    parameters,
                    commandType:
                    CommandType.StoredProcedure);
            }
        }
    }
}
