using Library.Core.Abstractions;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Abstactions.Repositories;

public interface IShelfRepository
{
    Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class;

    Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class;

    Task<ShelfAggregate?> GetAsync(Guid id, CancellationToken cancellationToken);

    IAsyncEnumerable<ShelfAggregate> GetAllAsync();
}
