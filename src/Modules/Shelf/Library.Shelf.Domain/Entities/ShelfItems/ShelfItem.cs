namespace Library.Shelf.Domain.Entities.ShelfItems;

public class ShelfItem
{
    public Guid Id { get; private set; }

    public bool IsDeleted { get; private set; }
}
