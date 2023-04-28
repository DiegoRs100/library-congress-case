using FluentValidation;

namespace Library.Account.Domain.Users.Validators
{
    public partial class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.VisitorId)
                .NotEmpty()
                .WithMessage("You must associate the user with a valid visitor.");

            RuleFor(u => u.Email.IsValid)
                .Equal(true)
                .WithMessage("Invalid Email.");

            RuleFor(U => U.Password)
                .Length(12, 50)
                .Must(p => p.Any(c => char.IsSymbol(c)))
                .Must(p => p.Any(c => char.IsDigit(c)))
                .Must(p => p.Any(c => char.IsAsciiLetterLower(c)))
                .Must(p => p.Any(c => char.IsAsciiLetterUpper(c)));
        }      
    }
}