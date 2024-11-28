using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Mapping;
using Users.Api.Services;

namespace Users.Api.Endpoints
{
    public class GetAllUsersEndpoint(IUserService _userService) : EndpointWithoutRequest<GetAllUsersResponse>
    {
        public override void Configure()
        {
            Get("users");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var users = await _userService.GetAllAsync();
            var response = users.ToUserResponse();
            await SendOkAsync(response, ct);
        }
    }
}