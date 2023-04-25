using FluentValidation.Results;
using Library.Core;

namespace Library.Account.Domain.Visitors
{
    public class Visitor : Entity, IAggregateRoot
    {
        public override ValidationResult Validate()
        {
            return new VisitorValidation().Validate(this);
        }
    }
}