using Microsoft.EntityFrameworkCore;

namespace Library.Api.DependencyInjection.Databases;

public class LibraryDbContext : DbContext
{

	public LibraryDbContext(DbContextOptions options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Shelf.Infra.Databases.Contexts.LibraryDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}
