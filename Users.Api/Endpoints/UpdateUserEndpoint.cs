using FastEndpoints;
using Users.Api.Contracts.Requests;
using Users.Api.Contracts.Responses;
using Users.Api.Mapping;
using Users.Api.Services;

namespace Users.Api.Endpoints
{
    public class UpdateUserEndpoint(IUserService _userService) : Endpoint<UpdateUserRequest, UserResponse>
    {
        public override void Configure()
        {
            Put("users/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
        {
            var user = req.ToUser();

            var updated = await _userService.UpdateAsync(user);
            if (!updated)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var response = user.ToUserResponse();
            await SendOkAsync(response, ct);
        }
    }
}