using Library.Shelf.Domain.Entities.ShelfItems;
using Library.Shelf.Domain.ValueObjects.Locations;

namespace Library.Shelf.Domain.Aggregates;

public class Shelf
{
    private readonly List<ShelfItem> _shelfItems = new();

    public Guid Id { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsDeleted { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public Location Location { get; private set; }

    public IReadOnlyCollection<ShelfItem> ShelfItems 
        => _shelfItems;

    //TODO: method overloading?
    public void CreateShelf() { }

    public void DeleteShelf() { }

    public void ActivateShelf() { }

    public void DeactivateShelf() { }

    public void AddShelfItem() { }

    public void RemoveShelfItem() { }

    public void ChangeShelfLocation() { }

    public void ChangeShelfTitle() { }

    public void ChangeShelfDescription() { }
}
