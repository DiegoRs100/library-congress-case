using Library.Shelf.Domain.Entities.ShelfItems;
using Library.Shelf.Domain.ValueObjects.Books;
using Library.Shelf.Infra.Databases.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Shelf.Infra.Databases.Configurations;

public class ShelfItemConfiguration : IEntityTypeConfiguration<ShelfItem>
{
    public void Configure(EntityTypeBuilder<ShelfItem> builder)
    {
        builder.ToTable(nameof(ShelfItem));

        builder.HasKey(nameof(ShelfItem.Id));

        builder
            .Property(prop => prop.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .Property(prop => prop.Price)
            .IsRequired();

        builder
            .Property(prop => prop.Quantity)
            .IsRequired();

        builder
            .HasOne(shelfItem => shelfItem.Shelf)
            .WithMany(shelf => shelf.Items)
            .HasForeignKey(shelfItem => shelfItem.ShelfId)
            .IsRequired();

        builder.OwnsOne(
            prop => prop.Book,
            bookNavigationBuilder =>
            {
                bookNavigationBuilder.ToTable(nameof(Book));

                bookNavigationBuilder.Property<int>("Id").IsRequired();
                bookNavigationBuilder.HasKey("Id");

                bookNavigationBuilder
                    .Property(nameof(Book.Name))
                    .IsRequired()
                    .HasMaxLength(200);

                bookNavigationBuilder
                    .Property(nameof(Book.Description))
                    .IsRequired()
                    .HasMaxLength(500);

                bookNavigationBuilder
                    .Property(nameof(Book.Author))
                    .IsRequired()
                    .HasMaxLength(100);

                bookNavigationBuilder
                    .Property(nameof(Book.Language))
                    .HasConversion<LanguageConverter>()
                    .IsRequired()
                    .HasMaxLength(10);

                bookNavigationBuilder
                    .Property(nameof(Book.Pages))
                    .IsRequired();

                bookNavigationBuilder
                    .Property(nameof(Book.PublicationAt))
                    .IsRequired();

                bookNavigationBuilder
                    .Property(nameof(Book.PublishingCompany))
                    .IsRequired()
                    .HasMaxLength(100);
            });
    }
}
