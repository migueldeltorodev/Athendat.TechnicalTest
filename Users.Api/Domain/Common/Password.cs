using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace Users.Api.Domain.Common
{
    public class Password : ValueOf<string, Password>
    {
        private static readonly Regex PasswordRegex =
            new("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*])[A-Za-z\\d!@#$%^&*]{8,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override void Validate()
        {
            if (!PasswordRegex.IsMatch(Value))
            {
                var message = $"{Value} is not a valid password";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(Password), message)
                });
            }
        }
    }
}