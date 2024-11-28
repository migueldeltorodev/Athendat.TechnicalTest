using FastEndpoints;
using Users.Api.Services;

namespace Users.Api.Endpoints
{
    public class DeleteUserEndpoint(IUserService _userService) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Delete("users/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>("id");

            var deleted = await _userService.DeleteAsync(id);
            if (!deleted)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendNoContentAsync(ct);
        }
    }
}