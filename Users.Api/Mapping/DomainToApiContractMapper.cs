using Users.Api.Contracts.Responses;
using Users.Api.Domain;

namespace Users.Api.Mapping
{
    public static class DomainToApiContractMapper
    {
        public static UserResponse ToUserResponse(this User user)
        {
            return new UserResponse
            {
                Id = user.Id.Value,
                Username = user.Username.Value,
                Password = user.Password.Value,
                Email = user.Email.Value
            };
        }

        public static GetAllUsersResponse ToUserResponse(this IEnumerable<User> users)
        {
            return new GetAllUsersResponse
            {
                Users = users.Select(x => new UserResponse
                {
                    Id = x.Id.Value,
                    Username = x.Username.Value,
                    Password = x.Password.Value,
                    Email = x.Email.Value
                })
            };
        }
    }
}