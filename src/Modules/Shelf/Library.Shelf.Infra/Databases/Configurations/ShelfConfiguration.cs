using Library.Shelf.Domain.ValueObjects.Locations;
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
            .IsRequired();

        builder
            .Property(prop => prop.IsDeleted)
            .IsRequired();

        builder
            .Property(prop => prop.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(prop => prop.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder
            .HasMany(shelf => shelf.Items)
            .WithOne(shelfItem => shelfItem.Shelf)
            .HasForeignKey(shelfItem => shelfItem.ShelfId)
            .IsRequired();

        builder
            .OwnsOne(
                prop => prop.Location,
                locationNavigationBuilder =>
                {
                    locationNavigationBuilder.ToTable(nameof(Location));

                    locationNavigationBuilder.Property<int>("Id").IsRequired();
                    locationNavigationBuilder.HasKey("Id");

                    locationNavigationBuilder
                        .Property(nameof(Location.Session))
                        .IsRequired()
                        .HasMaxLength(100);

                    locationNavigationBuilder
                        .Property(nameof(Location.Hall))
                        .IsRequired();

                    locationNavigationBuilder
                        .Property(nameof(Location.Bookcase))
                        .IsRequired();

                    locationNavigationBuilder
                        .Property(nameof(Location.Rack))
                        .IsRequired();
                });
    }
}
