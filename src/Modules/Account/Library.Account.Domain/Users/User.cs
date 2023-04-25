using Library.Account.Domain.Visitors;
using Library.Core;

namespace Library.Account.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Guid VisitorId { get; private set; }

        public User(Visitor visitor)
        {
            VisitorId = visitor.Id;
        }
    }
}