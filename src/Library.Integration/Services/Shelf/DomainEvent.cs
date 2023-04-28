using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class DomainEvent
{
    public record ShelfCreated(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message, IDomainEvent;

    public record ShelfDeleted(Guid ShelfId) : Message, IDomainEvent;

    public record ShelfActivated(Guid ShelfId) : Message, IDomainEvent;

    public record ShelfDeactivated(Guid ShelfId) : Message, IDomainEvent;

    public record ShelfItemAdded(Guid ShelfId, Guid ShelfItemId, Dto.Book Book, decimal Price, int Quantity) : Message, IDomainEvent;

    public record ShelfItemIncreased(Guid ShelfId, Guid ShelfItemId, Dto.Book Book, decimal Price, int Quantity) : Message, IDomainEvent;
}
