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

            return await _userRepository.CreateAsync(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetAsync(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            // We check if user exists
            var existingUser = await _userRepository.GetAsync(user.Id.Value);
            if (existingUser is not null)
            {
                return false;
            }

            return await _userRepository.UpdateAsync(user);
        }
    }
}