using Library.Shelf.Domain.Entities.ShelfItems;
using Library.Shelf.Domain.ValueObjects.Locations;

namespace Library.Shelf.Domain.Aggregates;

public class Shelf
{
    private readonly List<ShelfItem> _shelfItems = new();

    public string Title { get; private set; }

    public string Description { get; private set; }

    public Location Location { get; private set; }

    public IReadOnlyCollection<ShelfItem> ShelfItems 
        => _shelfItems;
}
