using Library.Integration.Abstractions.Messages;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Services;

public interface IApplicationService
{
    Task<ShelfAggregate> RecoverAggregateAsync(Guid guid, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<IDomainEvent>> SaveAggregateAsync<TEntity>(TEntity entity, IReadOnlyCollection<IDomainEvent> events, bool isNew, CancellationToken cancellationToken)
        where TEntity : class;
}
