using Library.Shelf.Domain.Aggregates;
using Library.Shelf.Domain.ValueObjects.Books;

namespace Library.Shelf.Domain.Entities.ShelfItems;

public class ShelfItem
{
    protected ShelfItem() { }

    public ShelfItem(bool isActive, Book book, decimal price, int quantity, Aggregates.Shelf shelf)
    {
        Id = Guid.NewGuid();
        IsActive = isActive;
        Book = book;
        Price = price;
        Quantity = quantity;
        Shelf = shelf;
        ShelfId = shelf.Id;
        IsModified = true;
    }

    public bool IsModified { get; private set; } = false;

    public Guid Id { get; }

    public bool IsActive { get; private set; } = true;

    public Book Book { get; }

    public decimal Price { get; }

    public int Quantity { get; private set; }

    public void Increase(int quantity)
    {
        Quantity += quantity;
        IsModified = true;
    }

    public void Decrease(int quantity)
    {
        Quantity -= quantity;
        IsModified = true;
    }

    public void Activate()
    {
        IsActive = true;
        IsModified= true;
    }

    public void Deactivate()
    {
        IsActive = false;
        IsModified = true;
    }

    #region Reference to navigation
    public Guid ShelfId { get; }
    public Aggregates.Shelf Shelf { get; } = null!;
    #endregion
}
