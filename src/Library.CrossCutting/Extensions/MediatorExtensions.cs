using MediatR;

namespace Library.Core.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task SendDomainEvents(this IMediator mediator, IEnumerable<Event> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await mediator.Send(domainEvent);
        }
    }
}