using ValueOf;

namespace Users.Api.Domain.Common
{
    public class Id : ValueOf<Guid, Id>
    {
        protected override void Validate()
        {
            if (Value == Guid.Empty)
            {
                throw new ArgumentException("User Id cannot be empty", nameof(Id));
            }
        }
    }
}