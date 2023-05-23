using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Shelf.Infra.Databases.Configurations;

public class ShelfConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Shelf>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Shelf> builder)
    {
        throw new NotImplementedException();
    }
}
