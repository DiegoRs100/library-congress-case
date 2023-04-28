using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class Command
{
    public record CreateShelf(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message, ICommand;

    public record DeleteShelf(Guid ShelfId) : Message, ICommand;

    public record ActivateShelf(Guid ShelfId) : Message, ICommand;

    public record DeactivateShelf(Guid ShelfId) : Message, ICommand;

    public record AddShelfItem(Guid ShelfId, Dto.Book Book, decimal Price, int Quantity) : Message, ICommand;

    public record RemoveShelfItem(Guid ShelfId, Guid ShelfItemId) : Message, ICommand;

    public record ChangeShelfLocation(Guid ShelfId, Dto.Location Location) : Message, ICommand;

    public record ChangeShelfTitle(Guid ShelfId, string Title) : Message, ICommand;
}