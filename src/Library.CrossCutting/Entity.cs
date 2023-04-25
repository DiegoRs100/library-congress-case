using FluentValidation.Results;

namespace Library.Core
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual ValidationResult Validate()
        {
            throw new NotImplementedException("Override the validate method on the domain entity.");
        }
    }
}