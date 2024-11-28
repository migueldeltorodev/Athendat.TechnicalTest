using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class GetUserSummary : Summary<GetUserEndpoint>
    {
        public GetUserSummary()
        {
            Summary = "Returns a single user by id";
            Description = "Returns a single user by id";
            Response<GetAllUsersResponse>(200, "Successfully found and returned the user");
            Response(401, "You need to be authenticated");
            Response(404, "The user does not exist in the system");
            Response(405, "Method not allowed");
        }
    }
}