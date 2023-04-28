namespace Library.Account.Application.Visitors.Dto_s
{
    public record AddressDto(
        string Street,
        string ZipCode,
        int Number,
        string Neighborhood,
        string City,
        string State);
}