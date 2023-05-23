using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Infra.Databases.Configurations;

public class ShelfConfiguration : IEntityTypeConfiguration<ShelfAggregate>
{
    public void Configure(EntityTypeBuilder<ShelfAggregate> builder)
    {
        builder.ToTable(nameof(ShelfAggregate));

        builder.HasKey(nameof(ShelfAggregate.Id));

        builder
            .Property(prop => prop.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder
            .Property(prop => prop.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(prop => prop.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(prop => prop.Description)
            .HasMaxLength(500)
            .IsRequired();
    }
}
