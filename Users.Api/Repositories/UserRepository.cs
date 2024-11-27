using Dapper;
using Microsoft.AspNetCore.Connections;
using Users.Api.Contracts.Data;
using Users.Api.Database;
using Users.Api.Domain;
using Users.Api.Mapping;

namespace Users.Api.Repositories
{
    public class UserRepository(IDbConnectionFactory _connectionFactory) : IUserRepository
    {
        public async Task<bool> CreateAsync(User user)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var userDto = user.ToUserDto();

            var result = await connection.ExecuteAsync(
                @"INSERT INTO Users (Id, Username, Password, Email)
                VALUES (@Id, @Username, @Password, @Email)",
                userDto);

            return result > 0;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var userDto = await connection.QuerySingleOrDefaultAsync<UserDto>(
                "SELECT * FROM Users WHERE Id = @Id",
                new { Id = id.ToString() });

            return userDto?.ToUser();
        }

        public Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}