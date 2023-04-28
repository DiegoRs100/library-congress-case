using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Domain.Entities.ShelfItems;
using Library.Shelf.Domain.ValueObjects.Locations;
using Library.Shelf.Domain.ValueTypes;

namespace Library.Shelf.Domain.Aggregates;

public partial class Shelf
{
    private readonly List<ShelfItem> _shelfItems = new();
    private readonly List<IDomainEvent> _shelfEvents = new();

    public Guid Id { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsDeleted { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public Location Location { get; private set; }

    public IReadOnlyCollection<ShelfItem> Items
        => _shelfItems;

    public IReadOnlyCollection<IDomainEvent> Events
        => _shelfEvents;

    public void Handle<TResult>(ICommand<TResult> command)
        => Handle(command as dynamic);

    private void Handle(Command.CreateShelf command)
        => ApplyEvent(new DomainEvent.ShelfCreated(command.ShelfId, command.Title, command.Description, command.Location));

    private void Handle(Command.DeleteShelf command)
        => ApplyEvent(new DomainEvent.ShelfDeleted(command.ShelfId));

    private void Handle(Command.ActivateShelf command) 
    {
        if (Items.Any() && IsActive is false)
            ApplyEvent(new DomainEvent.ShelfActivated(command.ShelfId));
    }

    public void Handle(Command.DeactivateShelf command) 
    {
        if (IsActive)
            ApplyEvent(new DomainEvent.ShelfDeactivated(command.ShelfId));
    }

    public void Handle(Command.AddShelfItem command)
        => ApplyEvent(new DomainEvent.ShelfItemAdded(command.ShelfId, command.Book, command.Price, command.Quantity));

    public void RemoveShelfItem() { }

    public void ChangeShelfLocation() { }

    public void ChangeShelfTitle() { }

    public void ChangeShelfDescription() { }

    private void ApplyEvent(IDomainEvent domainEvent)
    {
        _shelfEvents.Add(domainEvent);
        When(domainEvent as dynamic);
    }

    private void When(DomainEvent.ShelfCreated @event)
    {
        Id = @event.ShelfId;
        Title= @event.Title;
        Description= @event.Description;
        Location = @event.Location;
    }

    private void When(DomainEvent.ShelfDeleted _)
        => IsDeleted = true;

    private void When(DomainEvent.ShelfActivated _)
        => IsActive = true;

    private void When(DomainEvent.ShelfDeactivated _)
        => IsDeleted = false;

    private void When(DomainEvent.ShelfItemAdded @event)
        => _shelfItems.Add(new(false, @event.Book, @event.Price, @event.Quantity));
}
