using Library.Shelf.Domain.ValueTypes;

namespace Library.Shelf.Domain.ValueObjects.Books;

public record Book (string Name, string Description, string Author, Language Language)
{
}
