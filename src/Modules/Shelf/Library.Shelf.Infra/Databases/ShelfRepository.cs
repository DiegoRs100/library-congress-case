using Microsoft.EntityFrameworkCore;

using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Infra.Databases;

public class ShelfRepository
{
    private readonly DbContext _dbContext;

	public ShelfRepository(DbContext dbContext)
        => _dbContext = dbContext;

    public async Task UpsertAsync(ShelfAggregate aggregate, CancellationToken cancellationToken)
    {
        if (aggregate.Id == default)
            _dbContext.Set<ShelfAggregate>().Update(aggregate);
        else
            await _dbContext.Set<ShelfAggregate>().AddAsync(aggregate, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<ShelfAggregate?> GetAsync(Guid id, CancellationToken cancellationToken)
        => _dbContext.Set<ShelfAggregate>()
            .AsNoTracking()
            .FirstOrDefaultAsync(aggregate => aggregate.Id == id, cancellationToken);

    public IAsyncEnumerable<ShelfAggregate> GetAllAsync()
        => _dbContext.Set<ShelfAggregate>()
            .AsNoTracking()
            .AsAsyncEnumerable();
}
