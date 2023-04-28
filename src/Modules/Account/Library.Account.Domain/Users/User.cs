using FluentValidation.Results;
using Library.Account.Domain.Users.Validators;
using Library.Account.Domain.Visitors;
using Library.Account.Domain.Visitors.ValueObjects;
using Library.Core.Abstractions;
using static Library.Integration.Services.Account.UserDomainEvents;

namespace Library.Account.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Guid VisitorId { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; } = default!;
        public string FirstAccessPassword { get; private set; }

        public User(Visitor visitor)
        {
            VisitorId = visitor.Id;
            FirstAccessPassword = Guid.NewGuid().ToString();

            if (visitor.Email.HasValue)
                Email = visitor.Email.Value;

            AddDomainEvent(new UserCreated(visitor.Id));
        }

        public override ValidationResult Validate()
        {
            return new UserValidator().Validate(this);
        }
    }
}