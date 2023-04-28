using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class Command
{
    public record CreateShelf(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message, ICommand<Guid>;

    public record DeleteShelf(Guid ShelfId) : Message, ICommand<Guid>;

    public record ActivateShelf(Guid ShelfId) : Message, ICommand<Guid>;

    public record DeactivateShelf(Guid ShelfId) : Message, ICommand<Guid>;

    public record AddShelfItem(Guid ShelfId, Dto.Book Book, decimal Price, int Quantity) : Message, ICommand<Guid>;
}