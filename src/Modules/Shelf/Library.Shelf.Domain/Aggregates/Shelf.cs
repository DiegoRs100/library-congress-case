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

    public bool IsNewRegister { get; private set; } = false;
    
    public Type EntityModified { get; private set; } = typeof(Shelf);

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

    public void Handle(ICommand command)
        => Handle(command as dynamic);

    private void Handle(Command.CreateShelf command)
        => ApplyEvent(new DomainEvent.ShelfCreated(command.ShelfId, command.Title, command.Description, command.Location));

    private void Handle(Command.DeleteShelf command)
        => ApplyEvent(new DomainEvent.ShelfDeleted(command.ShelfId));

    private void Handle(Command.ActivateShelf command) 
    {
        if (IsActive is false)
            ApplyEvent(new DomainEvent.ShelfActivated(command.ShelfId));
    }

    private void Handle(Command.DeactivateShelf command) 
    {
        if (IsActive)
            ApplyEvent(new DomainEvent.ShelfDeactivated(command.ShelfId));
    }

    private void Handle(Command.AddShelfItem command)
    {
        var shelfItem = _shelfItems
            .Where(item => item.Book.Equals(command.Book))
            .SingleOrDefault(item => item.Price.Equals(command.Price));

        ApplyEvent(shelfItem is { IsActive: false }
            ? new DomainEvent.ShelfItemIncreased(command.ShelfId, shelfItem.Id, command.Book, command.Price, command.Quantity)
            : new DomainEvent.ShelfItemAdded(command.ShelfId, command.Book, command.Price, command.Quantity));
    }

    private void Handle(Command.ActiveShelfItem command)
        => ApplyEvent(new DomainEvent.ShelfItemActivated(command.ShelfId, command.ShelfItemId));

    private void Handle(Command.DeactiveShelfItem command)
        => ApplyEvent(new DomainEvent.ShelfItemDeactivated(command.ShelfId, command.ShelfItemId));

    private void Handle(Command.ChangeShelfLocation command)
        => ApplyEvent(new DomainEvent.LocationShelfChanged(command.ShelfId, command.Location));

    private void Handle(Command.ChangeShelfTitle command)
        => ApplyEvent(new DomainEvent.ShelfTitleChanged(command.ShelfId, command.Title));

    private void Handle(Command.ChangeShelfDescription command)
        => ApplyEvent(new DomainEvent.ShelfDescriptionChanged(command.ShelfId, command.Description));

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
        IsActive = true;

        IsNewRegister = true;
    }

    private void When(DomainEvent.ShelfDeleted _)
        => IsDeleted = true;

    private void When(DomainEvent.ShelfActivated _)
        => IsActive = true;

    private void When(DomainEvent.ShelfDeactivated _)
        => IsActive = false;

    private void When(DomainEvent.ShelfItemAdded @event)
    {
        _shelfItems.Add(new(false, @event.Book, @event.Price, @event.Quantity, this));
        IsNewRegister= true;
        EntityModified = typeof(ShelfItem);
    }

    private void When(DomainEvent.ShelfItemIncreased @event)
    {
        _shelfItems.Single(item => item.Id.Equals(@event.ShelfItemId)).Increase(@event.Quantity);
        EntityModified = typeof(ShelfItem);
    }

    private void When(DomainEvent.ShelfItemActivated @event)
    {
        _shelfItems.Single(item => item.Id.Equals(@event.ShelfItemId)).Activate();
        EntityModified = typeof(ShelfItem);
    }

    private void When(DomainEvent.ShelfItemDeactivated @event)
    {
        _shelfItems.Single(item => item.Id.Equals(@event.ShelfItemId)).Deactivate();
        EntityModified = typeof(ShelfItem);
    }

    private void When(DomainEvent.LocationShelfChanged @event)
        => Location = @event.Location;

    private void When(DomainEvent.ShelfTitleChanged @event)
        => Title = @event.Title;

    private void When(DomainEvent.ShelfDescriptionChanged @event)
        => Description = @event.Description;
}
