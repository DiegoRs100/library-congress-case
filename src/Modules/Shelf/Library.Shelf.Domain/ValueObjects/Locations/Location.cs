using Library.Integration.DataTransferObjects;

namespace Library.Shelf.Domain.ValueObjects.Locations;

public record Location(string Session, int Hall, int Bookcase, int Shelf) 
{ 
    public static implicit operator Location(Dto.Location location)
        => new(location.Session, location.Hall, location.Bookcase, location.Shelf);

    public static implicit operator Dto.Location(Location location)
        => new(location.Session, location.Hall, location.Bookcase, location.Shelf);
}