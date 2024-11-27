namespace Users.Api.Contracts.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string Email { get; init; } = default!;
    }
}