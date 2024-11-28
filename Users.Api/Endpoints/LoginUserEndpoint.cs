using FastEndpoints;
using Microsoft.AspNetCore.Identity.Data;
using Users.Api.Services;

namespace Users.Api.Endpoints
{
    public class LoginUserEndpoint(IAuthService _authService) : Endpoint<LoginRequest>
    {
        public override void Configure()
        {
            Post("login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            try
            {
                var token = await _authService.LoginAsync(req.Email, req.Password);
                await SendOkAsync(new { Token = token }, ct);
            }
            catch (UnauthorizedAccessException)
            {
                await SendUnauthorizedAsync(ct);
            }
        }
    }
}