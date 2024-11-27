using FastEndpoints;
using Users.Api.Contracts.Requests;
using Users.Api.Contracts.Responses;
using Users.Api.Mapping;
using Users.Api.Services;

namespace Users.Api.Endpoints
{
    public class CreateUserEndpoint(IUserService _userService) : Endpoint<CreateUserRequest, UserResponse>
    {
        public override void Configure()
        {
            Post("users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
        {
            var user = req.ToUser();

            await _userService.CreateAsync(user);

            var response = user.ToUserResponse();
            await SendCreatedAtAsync<GetUserEndpoint>(
                new { Id = user.Id },
                response,
                generateAbsoluteUrl: true,
                cancellation: ct);
        }
    }
}