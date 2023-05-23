using Library.Shelf.Domain.ValueObjects.Locations;
using Library.Shelf.Infra.Databases.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Shelf.Infra.Databases.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable(nameof(Location));

        builder.Property<int>("Id").IsRequired();
        builder.HasKey("Id");

        builder
            .Property(nameof(Location.Session))
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(nameof(Location.Hall))
            .IsRequired();

        builder
            .Property(nameof(Location.Bookcase))
            .IsRequired();

        builder
            .Property(nameof(Location.Shelf))
            .IsRequired();
    }
}
