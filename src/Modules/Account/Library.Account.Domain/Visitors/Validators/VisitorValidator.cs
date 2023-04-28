using FluentValidation;
using System.Text.RegularExpressions;

namespace Library.Account.Domain.Visitors
{
    public partial class VisitorValidator : AbstractValidator<Visitor>
    {
        [GeneratedRegex("^(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4}$")]
        private static partial Regex SsnRegex();

        public VisitorValidator()
        {
            RuleFor(v => v.Ssn)
                .Matches(SsnRegex())
                .WithMessage("Invalid Ssn.");

            RuleFor(v => v.Name)
                .Length(3, 50)
                .WithMessage("Visitor's name must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(v => v.Birthday)
                .NotEmpty()
                .WithMessage("Visitor's Birthday must be informed.");

            RuleFor(v => v.Email.HasValue)
                .Equal(true)
                .WithMessage("Invalid Email.");

            RuleFor(v => v.Address).SetValidator(new AddressValidator());
        }        
    }
}