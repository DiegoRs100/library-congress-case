using Library.Integration.Abstractions.Messages;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Services;

public interface IApplicationService
{
    Task<ShelfAggregate> RecoverAggregateAsync(Guid guid, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<IDomainEvent>> SaveAggregateAsync(ShelfAggregate aggregate, bool isNew, CancellationToken cancellationToken);
}
