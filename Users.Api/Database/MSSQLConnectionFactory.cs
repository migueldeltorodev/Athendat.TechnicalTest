using Microsoft.Data.SqlClient;
using System.Data;

namespace Users.Api.Database
{
    public class MSSQLConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public MSSQLConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}