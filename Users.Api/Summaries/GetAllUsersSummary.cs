using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class GetAllUsersSummary : Summary<GetAllUsersEndpoint>
    {
        public GetAllUsersSummary()
        {
            Summary = "Returns all the users in the system";
            Description = "Returns all the users in the system";
            Response<GetAllUsersResponse>(200, "All users in the system are returned");
            Response(401, "You need to be authenticated");
            Response(405, "Method not allowed");
        }
    }
}