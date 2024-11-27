using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Mapping;
using Users.Api.Services;

namespace Users.Api.Endpoints
{
    public class GetUserEndpoint(IUserService _userService) : EndpointWithoutRequest<UserResponse>
    {
        public override void Configure()
        {
            Get("users/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>("id");

            var user = await _userService.GetAsync(id);
            if (user is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var response = user.ToUserResponse();
            await SendOkAsync(response, ct);
        }
    }
}