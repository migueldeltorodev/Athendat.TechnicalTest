﻿using FastEndpoints;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class DeleteUserSummary : Summary<DeleteUserEndpoint>
    {
        public DeleteUserSummary()
        {
            Summary = "Deleted a user in the system";
            Description = "Deleted a user in the system";
            Response(204, "The user was deleted successfully");
            Response(404, "The user was not found in the system");
        }
    }
}