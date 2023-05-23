using Library.Rent.Domain.Books;
using Library.Shelf.Domain.Entities.ShelfItems;
using Library.Shelf.Domain.ValueObjects.Locations;
using Microsoft.EntityFrameworkCore;

using AggregateRoot = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Infra.Databases.Contexts;

public class ShelfDbContext : DbContext
{
    public DbSet<AggregateRoot>? Shelfs { get; set; }
    public DbSet<ShelfItem>? ShelfItems { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Location>? Locations { get; set; }

    public ShelfDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}
