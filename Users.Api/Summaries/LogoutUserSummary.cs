using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class LogoutUserSummary : Summary<LogoutUserEndpoint>
    {
        public LogoutUserSummary()
        {
            Summary = "End a user sesion endpoint";
            Description = "End a user sesion endpoint";
            Response(200, "You are not currenly authenticated!");
        }
    }
}