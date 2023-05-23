using Microsoft.EntityFrameworkCore;

using AggregateRoot = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Infra.Databases.Contexts;

public partial class LibraryDbContext
{
    public DbSet<AggregateRoot>? Shelf { get; set; }
}
