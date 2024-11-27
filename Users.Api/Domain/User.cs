using Users.Api.Domain.Common;

namespace Users.Api.Domain
{
    public class User
    {
        public Id Id { get; init; } = Id.From(Guid.NewGuid());
        public Username Username { get; init; } = default!;
        public Password Password { get; init; } = default!;
        public Email Email { get; init; } = default!;
    }
}