using Dapper;
using OrderSystem.Data;
using OrderSystem.Exceptions;
using OrderSystem.Models;
using OrderSystem.Repository.Contracts;
using System.Data;

namespace OrderSystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private DapperContext _dapperContext;

        public CustomerRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Customer> CreateCustommer(Customer customer)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("FirstName", customer.FirstName, DbType.String);
            parameters.Add("LastName", customer.LastName, DbType.String);
            parameters.Add("Email", customer.Email, DbType.String);
            parameters.Add("PhoneNumber", customer.PhoneNumber, DbType.String);

            using var connection = _dapperContext.CreateConnection();
            {
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(
                    "spCreateCustomer",
                    parameters,
                    commandType:
                    CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            var connection = _dapperContext.CreateConnection();

            return (await connection.QueryAsync<Customer>(
                "spCustomersGetAll",
                commandType:
                CommandType.StoredProcedure))
                .ToList();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", email);

            using var connection = _dapperContext.CreateConnection();
            {


            var customer = await connection.QuerySingleOrDefaultAsync<Customer>(
                "spCustomerGetByEmail",
                parameters,
                commandType:
                CommandType.StoredProcedure);

                return customer ?? throw new EntityNotFoundException("Customer not found.");
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                var customer = await connection.QuerySingleOrDefaultAsync<Customer>(
                "spCustomerGetById",
                parameters,
                commandType:
                CommandType.StoredProcedure);

                return customer ?? throw new EntityNotFoundException("Customer not found.");
            }
        }

        public async Task<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PhoneNumber", phoneNumber);

            using var connection = _dapperContext.CreateConnection();
            {
                var customer = await connection.QuerySingleOrDefaultAsync<Customer>(
                    "spCustomerGetByPhoneNumber",
                    parameters,
                    commandType:
                    CommandType.StoredProcedure);

                return customer ?? throw new EntityNotFoundException("Customer not found.");
            }
        }
    }
}
