using Users.Api.Contracts.Data;
using Users.Api.Domain;

namespace Users.Api.Mapping
{
    public static class DomainToDtoMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id.Value.ToString(),
                Username = user.Username.Value,
                Password = user.Password.Value,
                Email = user.Email.Value,
            };
        }
    }
}