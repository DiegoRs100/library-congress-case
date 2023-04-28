namespace Library.Integration.DataTransferObjects;

public static class Dto
{
    public record Location(string Session, int Hall, int Bookcase, int Shelf);
}
