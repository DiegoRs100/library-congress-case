using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class Command
{
    public record CreateShelf(string Title, string Description, Dto.Location Location) : Message, ICommand;

    public record DeleteShelf() : Message, ICommand;

    public record ActivateShelf() : Message, ICommand;

    public record DeactivateShelf() : Message, ICommand;

    public record AddShelfItem(Dto.Book Book, decimal Price, int Quantity) : Message, ICommand;

    public record RemoveShelfItem(Guid ShelfItemId) : Message, ICommand;

    public record ChangeShelfLocation(Dto.Location Location) : Message, ICommand;

    public record ChangeShelfTitle(string Title) : Message, ICommand;

    public record ChangeShelfDescription(string Description) : Message, ICommand;
}