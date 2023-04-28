using Microsoft.EntityFrameworkCore;

namespace Library.Api.DependencyInjection.Databases;

public partial class DbContext : DbContext
{

	public Context(DbContextOptions options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
}
