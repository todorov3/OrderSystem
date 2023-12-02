using Microsoft.Data.SqlClient;
using System.Data;

namespace OrderSystem.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration, string connectionString = "DefaultConnection")
        {
            _connectionString = configuration.GetConnectionString(connectionString);
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
