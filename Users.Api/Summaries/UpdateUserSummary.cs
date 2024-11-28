using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class UpdateUserSummary : Summary<UpdateUserEndpoint>
    {
        public UpdateUserSummary()
        {
            Summary = "Updates an existing user in the system";
            Description = "Updates an existing user in the system";
            Response<UserResponse>(201, "User was successfully updated");
            Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        }
    }
}