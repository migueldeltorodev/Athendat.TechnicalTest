using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class RegisterUserSummary : Summary<RegisterUserEndpoint>
    {
        public RegisterUserSummary()
        {
            Summary = "Register a new user in the system";
            Description = "Register a new user in the system";
            Response<UserResponse>(201, "User was successfully registered");
            Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        }
    }
}