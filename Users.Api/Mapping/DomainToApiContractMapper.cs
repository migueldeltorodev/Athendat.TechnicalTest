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
    }
}