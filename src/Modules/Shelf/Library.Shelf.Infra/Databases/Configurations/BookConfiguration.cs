using Library.Shelf.Domain.ValueObjects.Books;
using Library.Shelf.Infra.Databases.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Shelf.Infra.Databases.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(nameof(Book));

        builder.Property<int>("Id").IsRequired();
        builder.HasKey("Id");

        builder
            .Property(nameof(Book.Name))
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(nameof(Book.Description))
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(nameof(Book.Author))
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(nameof(Book.Language))
            .HasConversion<LanguageConverter>()
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(nameof(Book.Pages))
            .IsRequired();

        builder
            .Property(nameof(Book.PublicationAt))
            .IsRequired();

        builder
            .Property(nameof(Book.PublishingCompany))
            .IsRequired()
            .HasMaxLength(100);
    }
}
