using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Domain.Entities.ShelfItems;
using Library.Shelf.Domain.ValueObjects.Locations;

namespace Library.Shelf.Domain.Aggregates;

public class Shelf
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

    public void Handle(ICommand command)
        => Handle(command as dynamic);

    public void Handle(Command.CreateShelf command)
        => ApplyEvent(new DomainEvent.ShelfCreated(Guid.NewGuid(), command.Title, command.Description, command.Location));

    public void DeleteShelf() 
        => IsDeleted = true;

    public void ActivateShelf() 
    {
        if (Items.Any() && IsActive is false)
            IsActive = true;
    }

    public void DeactivateShelf() 
    { 
        if(IsActive)
            IsActive = false;
    }

    public void AddShelfItem() { }

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
}
