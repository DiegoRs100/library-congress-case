using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class Command
{
    public record CreateShelf(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message(ShelfId), ICommand;

    public record DeleteShelf(Guid ShelfId) : Message(ShelfId), ICommand;

    public record ActivateShelf(Guid ShelfId) : Message(ShelfId), ICommand;

    public record DeactivateShelf(Guid ShelfId) : Message(ShelfId), ICommand;

    public record AddShelfItem(Guid ShelfId, Dto.Book Book, decimal Price, int Quantity) : Message(ShelfId), ICommand;

    public record ActiveShelfItem(Guid ShelfId, Guid ShelfItemId) : Message(ShelfId), ICommand;

    public record DeactiveShelfItem(Guid ShelfId, Guid ShelfItemId) : Message(ShelfId), ICommand;

    public record ChangeShelfLocation(Guid ShelfId, Dto.Location Location) : Message(ShelfId), ICommand;

    public record ChangeShelfTitle(Guid ShelfId, string Title) : Message(ShelfId), ICommand;

    public record ChangeShelfDescription(Guid ShelfId, string Description) : Message(ShelfId), ICommand;
}