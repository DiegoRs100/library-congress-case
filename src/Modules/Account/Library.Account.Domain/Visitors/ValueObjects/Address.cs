namespace Library.Account.Domain.Visitors.ValueObjects
{
    public record Address(
        string Street,
        string ZipCode,
        int Number,
        string Neighborhood,
        string City,
        string State);
}