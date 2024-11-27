using Users.Api.Contracts.Requests;
using Users.Api.Domain;
using Users.Api.Domain.Common;

namespace Users.Api.Mapping
{
    public static class ApiContractToDomainMapper
    {
        //public static User ToUser(this Contracts.Requests.LoginRequest request)
        //{
        //    return new User
        //    {
        //    };
        //}

        public static User ToUser(this CreateUserRequest request)
        {
            return new User
            {
                Id = Id.From(Guid.NewGuid()),
                Username = Username.From(request.UserName),
                Password = Password.From(request.Password),
                Email = Email.From(request.Email),
            };
        }

        public static User ToUser(this UpdateUserRequest request)
        {
            return new User
            {
                Id = Id.From(request.Id),
                Username = Username.From(request.UserName),
                Password = Password.From(request.Password),
                Email = Email.From(request.Email),
            };
        }
    }
}