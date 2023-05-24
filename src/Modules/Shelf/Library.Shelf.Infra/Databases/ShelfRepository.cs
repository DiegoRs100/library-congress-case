using Library.Shelf.Application.Abstactions.Repositories;
using Microsoft.EntityFrameworkCore;

using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Infra.Databases;

public class ShelfRepository : IShelfRepository
{
    private readonly DbContext _dbContext;

	public ShelfRepository(DbContext dbContext)
        => _dbContext = dbContext;

    public async Task InsertAsync(ShelfAggregate aggregate, CancellationToken cancellationToken)
    {
        await _dbContext.Set<ShelfAggregate>().AddAsync(aggregate, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(ShelfAggregate aggregate, CancellationToken cancellationToken)
    {
        _dbContext.Set<ShelfAggregate>().Update(aggregate);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<ShelfAggregate?> GetAsync(Guid id, CancellationToken cancellationToken)
        => _dbContext.Set<ShelfAggregate>()
            .FirstOrDefaultAsync(aggregate => aggregate.Id == id, cancellationToken);

    public IAsyncEnumerable<ShelfAggregate> GetAllAsync()
        => _dbContext.Set<ShelfAggregate>()
            .AsAsyncEnumerable();
}
