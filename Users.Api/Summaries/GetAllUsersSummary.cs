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
        }
    }
}