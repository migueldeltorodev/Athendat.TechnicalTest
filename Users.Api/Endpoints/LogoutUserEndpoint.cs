using FastEndpoints;
using Microsoft.AspNetCore.Authentication;

namespace Users.Api.Endpoints
{
    public class LogoutUserEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Post("logout");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await HttpContext.SignOutAsync("Cookies");
            await SendNoContentAsync(ct);
        }
    }
}