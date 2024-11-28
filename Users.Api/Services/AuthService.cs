using Identity.Api;
using Users.Api.Repositories;

namespace Users.Api.Services
{
    public class AuthService(IUserRepository _userRepository, TokenGenerator _tokenGenerator) : IAuthService
    {
        public async Task<string> LoginAsync(string email, string password)
        {
            // we get the user by email
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || user.Password.Value != password)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return _tokenGenerator.GenerateToken(email);
        }
    }
}