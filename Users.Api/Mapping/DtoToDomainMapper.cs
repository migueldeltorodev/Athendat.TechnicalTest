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
                Id = Id.From(userDto.Id),
                Username = Username.From(userDto.Username),
                Password = Password.From(userDto.Password),
                Email = Email.From(userDto.Email)
            };
        }
    }
}