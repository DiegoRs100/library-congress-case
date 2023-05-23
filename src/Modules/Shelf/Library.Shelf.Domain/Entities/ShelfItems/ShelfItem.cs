using Library.Shelf.Domain.Aggregates;
using Library.Shelf.Domain.ValueObjects.Books;

namespace Library.Shelf.Domain.Entities.ShelfItems;

public class ShelfItem
{
    public ShelfItem(bool isDeleted, Book book, decimal price, int quantity)
    {
        Id = Guid.NewGuid();
        IsDeleted = isDeleted;
        Book = book;
        Price = price;
        Quantity = quantity;
    }

    public Guid Id { get; }

    public bool IsDeleted { get; }

    public Book Book { get; }

    public decimal Price { get; }

    public int Quantity { get; private set; }

    public void Increase(int quantity)
        => Quantity += quantity;

    public void Decrease(int quantity)
        => Quantity -= quantity;


    #region Reference to navigation
    public int ShelfId { get; }
    public Aggregates.Shelf Shelf { get; } = null!;
    #endregion
}
