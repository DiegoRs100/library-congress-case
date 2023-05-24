using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Abstactions.Repositories;

public interface IShelfRepository
{
    Task UpsertAsync(ShelfAggregate aggregate, CancellationToken cancellationToken);

    Task<ShelfAggregate?> GetAsync(Guid id, CancellationToken cancellationToken);

    IAsyncEnumerable<ShelfAggregate> GetAllAsync();
}
