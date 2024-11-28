using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class CreateUserSummary : Summary<CreateUserEndpoint>
    {
        public CreateUserSummary()
        {
            Summary = "Creates a new user in the system";
            Description = "Creates a new user in the system";
            Response<UserResponse>(201, "User was successfully created");
            Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        }
    }
}