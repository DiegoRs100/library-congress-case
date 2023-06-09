﻿using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class DomainEvent
{
    public record ShelfCreated(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message(ShelfId), IDomainEvent;

    public record ShelfDeleted(Guid ShelfId) : Message(ShelfId), IDomainEvent;

    public record ShelfActivated(Guid ShelfId) : Message(ShelfId), IDomainEvent;

    public record ShelfDeactivated(Guid ShelfId) : Message(ShelfId), IDomainEvent;

    public record ShelfItemAdded(Guid ShelfId, Dto.Book Book, decimal Price, int Quantity) : Message(ShelfId), IDomainEvent;

    public record ShelfItemIncreased(Guid ShelfId, Guid ShelfItemId, Dto.Book Book, decimal Price, int Quantity) : Message(ShelfId), IDomainEvent;

    public record ShelfItemActivated(Guid ShelfId, Guid ShelfItemId) : Message(ShelfId), IDomainEvent;
    
    public record ShelfItemDeactivated(Guid ShelfId, Guid ShelfItemId) : Message(ShelfId), IDomainEvent;

    public record LocationShelfChanged(Guid ShelfId, Dto.Location Location) : Message(ShelfId), IDomainEvent;

    public record ShelfTitleChanged(Guid ShelfId, string Title) : Message(ShelfId), IDomainEvent;

    public record ShelfDescriptionChanged(Guid ShelfId, string Description) : Message(ShelfId), IDomainEvent;
}
