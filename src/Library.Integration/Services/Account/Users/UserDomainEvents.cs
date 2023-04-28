using Library.Integration.Abstractions.Messages;

namespace Library.Integration.Services.Account.Users
{
    public static class UserDomainEvents
    {
        public record UserCreated(Guid UserId) : Message, IDomainEvent;
    }
}