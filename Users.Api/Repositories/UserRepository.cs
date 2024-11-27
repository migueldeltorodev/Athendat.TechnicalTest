using Dapper;
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                "DELETE FROM Users WHERE Id = @Id",
                new { Id = id.ToString() });

            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var userDtos = await connection.QueryAsync<UserDto>(
                "SELECT * FROM Users");

            return userDtos.Select(dto => dto.ToUser());
        }

        public async Task<User?> GetAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var userDto = await connection.QuerySingleOrDefaultAsync<UserDto>(
                "SELECT * FROM Users WHERE Id = @Id",
                new { Id = id.ToString() });

            return userDto?.ToUser();
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var userDto = user.ToUserDto();

            var result = await connection.ExecuteAsync(
                @"UPDATE Users SET
                Username = @Username,
                Password = @Password,
                Email = @Email,
                WHERE Id = @Id",
                userDto);

            return result > 0;
        }
    }
}