using Library.Account.Domain.Visitors;
using Library.Core.Abstractions;
using static Library.Integration.Services.Account.Users.UserDomainEvents;

namespace Library.Account.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Guid VisitorId { get; private set; }

        public User(Visitor visitor)
        {
            VisitorId = visitor.Id;
            AddDomainEvent(new UserCreated(visitor.Id));
        }
    }
}