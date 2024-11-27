namespace Users.Api.Contracts.Requests
{
    public class UpdateUserRequest
    {
        public Guid Id { get; init; }
        public string UserName { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string Email { get; init; } = default!;
    }
}