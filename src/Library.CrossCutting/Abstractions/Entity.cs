using FluentValidation.Results;
using Library.Integration.Abstractions.Messages;

namespace Library.Core.Abstractions
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        private List<IDomainEvent> DomainEvents { get; set; } = new();

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public IEnumerable<IDomainEvent> GetDomainEvents()
        {
            return DomainEvents;
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }

        public virtual ValidationResult Validate()
        {
            throw new NotImplementedException("Override the validate method on the domain entity.");
        }
    }
}