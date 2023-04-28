using Ardalis.SmartEnum;

namespace Library.Shelf.Domain.Enumerations;

public sealed class Category : SmartEnum<Category>
{
    public static readonly Category Administration = new(nameof(Administration), 1);
    public static readonly Category ComputerScience = new(nameof(ComputerScience), 2);
    public static readonly Category HumanScience = new(nameof(Administration), 3);
    public static readonly Category Law = new(nameof(Administration), 4);
    public static readonly Category Enginer = new(nameof(Enginer), 5);
    public static readonly Category Medicine = new(nameof(Medicine), 6);

    public Category(string name, int value) 
        : base(name, value) { }

    public static implicit operator string(Category category)
        => category.Name;
}
