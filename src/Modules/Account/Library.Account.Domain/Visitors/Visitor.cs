using FluentValidation.Results;
using Library.Account.Domain.Visitors.Enums;
using Library.Account.Domain.Visitors.ValueObjects;
using Library.Core;
using EmailObject = Library.Account.Domain.Visitors.ValueObjects.Email;

namespace Library.Account.Domain.Visitors
{
    public class Visitor : Entity, IAggregateRoot
    {
        public string Ssn { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public DateOnly Birthday { get; private set; } = default!;
        public Gender Gender { get; set; }
        public EmailObject? Email { get; private set; } = default!;
        public Address Address { get; private set; } = default!;

        private Visitor()
        {
            // EF Core
        }

        public Visitor(string ssn, string name, DateOnly birthday, Gender gender, string email, Address address)
        {
            Ssn = ssn;
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Address = address;

            _ = EmailObject.TryParse(email, out var emailAux);
            Email = emailAux;
        }

        public override ValidationResult Validate()
        {
            return new VisitorValidator().Validate(this);
        }
    }
}