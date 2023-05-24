using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class DomainEvent
{
    public record ShelfCreated(string Title, string Description, Dto.Location Location) : Message, IDomainEvent;

    public record ShelfDeleted() : Message, IDomainEvent;

    public record ShelfActivated() : Message, IDomainEvent;

    public record ShelfDeactivated() : Message, IDomainEvent;

    public record ShelfItemAdded(Guid ShelfItemId, Dto.Book Book, decimal Price, int Quantity) : Message, IDomainEvent;

    public record ShelfItemIncreased(Guid ShelfItemId, Dto.Book Book, decimal Price, int Quantity) : Message, IDomainEvent;

    public record ShelfItemRemoved(Guid ShelfItemId) : Message, IDomainEvent;

    public record LocationShelfChanged(Dto.Location Location) : Message, IDomainEvent;

    public record ShelfTitleChanged(string Title) : Message, IDomainEvent;

    public record ShelfDescriptionChanged(string Description) : Message, IDomainEvent;
}
