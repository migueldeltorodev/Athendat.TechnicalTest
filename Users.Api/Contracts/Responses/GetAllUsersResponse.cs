namespace Users.Api.Contracts.Responses
{
    public class GetAllUsersResponse
    {
        public IEnumerable<UserResponse> Customers { get; init; } = Enumerable.Empty<UserResponse>();
    }
}