﻿using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class DomainEvent
{
    public record ShelfCreated(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message, IDomainEvent;

    public record ShelfDeleted(Guid ShelfId) : Message, IDomainEvent;
}