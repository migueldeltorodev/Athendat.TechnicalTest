using FluentValidation;
using Users.Api.Domain;
using Users.Api.Repositories;

namespace Users.Api.Services
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<bool> CreateAsync(User user)
        {
            // UserExists?
            var existingUser = await _userRepository.GetAsync(user.Id.Value);
            if (existingUser is not null)
            {
                throw new ValidationException($"A user with id {user.Id.Value} already exists");
            }
            // Email in Use?
            var users = await _userRepository.GetAllAsync();
            if (users.Any(x => x.Email.Equals(user.Email.Value)))
            {
                throw new ValidationException($"A user with email {user.Email.Value} already exists");
            }

            return await _userRepository.CreateAsync(user);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}