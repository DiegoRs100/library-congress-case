using FluentValidation;
using Library.Account.Domain.Visitors.ValueObjects;
using System.Text.RegularExpressions;

namespace Library.Account.Domain.Visitors
{
    public partial class AddressValidator : AbstractValidator<Address>
    {
        [GeneratedRegex("^[0-9]{5}-[0-9]{3}$")]
        private static partial Regex ZipCodeRegex();

        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .Length(3, 50)
                .WithMessage("Visitor's street must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(a => a.Neighborhood)
                .Length(3, 50)
                .WithMessage("Visitor's neighborhood must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(a => a.City)
                .Length(3, 50)
                .WithMessage("Visitor's city must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(a => a.State)
                .Length(3, 50)
                .WithMessage("Visitor's state must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(a => a.Number)
               .NotEmpty()
               .WithMessage("Visitor's state must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(a => a.ZipCode)
                .Matches(ZipCodeRegex())
                .WithMessage("Visitor's zip code invalid.");
        }
    }
}