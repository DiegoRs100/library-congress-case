using Library.Integration.Abstractions.Messages;

namespace Library.Integration.Services.Account
{
    public static class UserDomainEvents
    {
        public record UserCreated(Guid UserId) : Message(UserId), IDomainEvent;
    }
}