using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class LoginUserSummary : Summary<LoginUserEndpoint>
    {
        public LoginUserSummary()
        {
            Summary = "Login a single user by email and password";
            Description = "Login a single user by email and password";
            Response<GetAllUsersResponse>(200, "Successfully login!");
            Response(401, "The email or the password are wrong");
            Response(404, "The user does not exist in the system");
        }
    }
}