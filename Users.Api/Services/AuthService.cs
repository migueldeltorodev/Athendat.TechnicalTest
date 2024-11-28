using Identity.Api;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Users.Api.Repositories;

namespace Users.Api.Services
{
    public class AuthService(IUserRepository _userRepository, TokenGenerator _tokenGenerator) : IAuthService
    {
        public async Task<string> LoginAsync(string email, string password, HttpContext httpContext)
        {
            // we get the user by email
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || user.Password.Value != password)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = _tokenGenerator.GenerateToken(email);

            // Cookie configuration
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "login");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync("Cookies", claimsPrincipal, new AuthenticationProperties
            {
                IsPersistent = true, // Keep the session
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60) // Cookie expiration time
            });

            return token;
        }
    }
}