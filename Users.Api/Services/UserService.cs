using FluentValidation;
using Microsoft.AspNetCore.SignalR;
using Users.Api.Domain;
using Users.Api.Hubs;
using Users.Api.Repositories;

namespace Users.Api.Services
{
    public class UserService(IUserRepository _userRepository, IHubContext<NotificationHub> _hubContext) : IUserService
    {
        public async Task<bool> CreateAsync(User user)
        {
            // UserExists?
            var existingUser = await _userRepository.GetAsync(user.Id.Value);
            if (existingUser is not null)
            {
                throw new ValidationException($"A user with id {user.Id.Value} already exists");
            }

            var result = await _userRepository.CreateAsync(user);

            if (result)
            {
                // We emmit the registration notification
                await _hubContext.Clients.All.SendAsync("ReceiveOperationNotification", user.Username.Value, "new user has been registered");
            }

            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _userRepository.DeleteAsync(id);
            if (result is not false)
            {
                // We emmit the delete notification
                await _hubContext.Clients.All.SendAsync("ReceiveOperationNotification", "deleted a user");
            }
            return result;
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
            if (existingUser is null)
            {
                return false;
            }

            var result = await _userRepository.UpdateAsync(user);

            if (result)
            {
                // Emmit notification of update
                await _hubContext.Clients.All.SendAsync("ReceiveOperationNotification", user.Username.Value, "updated a user");
            }

            return result;
        }
    }
}