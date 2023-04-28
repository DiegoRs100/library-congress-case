using MediatR;

namespace Library.Core.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task PublishDomainEvents(this IMediator mediator, IEnumerable<Event> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}