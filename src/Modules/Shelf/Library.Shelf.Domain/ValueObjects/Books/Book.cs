using Library.Integration.DataTransferObjects;
using Library.Shelf.Domain.ValueTypes;

namespace Library.Shelf.Domain.ValueObjects.Books;

public record Book (
    string Name, 
    string Description, 
    string Author, 
    Language Language, 
    int Pages, 
    DateTime PublicationAt,
    string PublishingCompany) 
{
    public static implicit operator Book(Dto.Book book)
        => new(book.Name, book.Description, book.Author, book.Language, book.Pages, book.PublicationAt.ToDateTime(TimeOnly.MinValue), book.PublishingCompany);
}