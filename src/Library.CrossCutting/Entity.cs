using FluentValidation.Results;

namespace Library.Core
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        private List<Event> DomainEvents { get; set; } = new();

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public IEnumerable<Event> GetDomainEvents()
        {
            return DomainEvents;
        }

        public void AddDomainEvent(Event domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }

        public virtual ValidationResult Validate()
        {
            throw new NotImplementedException("Override the validate method on the domain entity.");
        }
    }
}