using Users.Api.Contracts.Data;
using Users.Api.Domain;
using Users.Api.Domain.Common;

namespace Users.Api.Mapping
{
    public static class DtoToDomainMapper
    {
        public static User ToUser(this UserDto userDto)
        {
            return new User
            {
                Id = Id.From(Guid.Parse(userDto.Id)),
                Username = Username.From(userDto.Username),
                Email = Email.From(userDto.Email),
                Password = Password.From(userDto.Password),
            };
        }
    }
}