using Library.Shelf.Application.Abstactions.Repositories;
using Library.Shelf.Domain.Entities.ShelfItems;
using Microsoft.EntityFrameworkCore;

using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Infra.Databases;

public class ShelfRepository : IShelfRepository
{
    private readonly DbContext _dbContext;

	public ShelfRepository(DbContext dbContext)
        => _dbContext = dbContext;

    public async Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
        where TEntity : class
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<ShelfAggregate?> GetAsync(Guid id, CancellationToken cancellationToken)
        => _dbContext
            .Set<ShelfAggregate>()
            .Include(prop => prop.Items)
            .FirstOrDefaultAsync(aggregate => aggregate.Id == id, cancellationToken);

    public IAsyncEnumerable<ShelfAggregate> GetAllAsync()
        => _dbContext
            .Set<ShelfAggregate>()
            .Include(prop => prop.Items)
            .AsAsyncEnumerable();
}
