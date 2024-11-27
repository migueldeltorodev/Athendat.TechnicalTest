using Dapper;

namespace Users.Api.Database
{
    public class DatabaseInitializer
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DatabaseInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(@"
            CREATE TABLE IF NOT EXISTS Users (
                Id UNIQUEIDENTIFIER PRIMARY KEY,
                Username NVARCHAR(39) NOT NULL,
                Password NVARCHAR(256) NOT NULL,
                Email NVARCHAR(256) NOT NULL
            )");
        }
    }
}