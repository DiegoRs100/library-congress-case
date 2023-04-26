using FluentValidation.Results;
using Library.Core;

namespace Library.Account.Domain.Visitors
{
    public class Visitor : Entity, IAggregateRoot
    {
        public string Ssn { get; private set; } = default!;

        public override ValidationResult Validate()
        {
            return new VisitorValidation().Validate(this);
        }
    }
}