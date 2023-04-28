using Library.Account.Domain.Visitors.Enums;

namespace Library.Account.Application.Visitors.Dto_s
{
    public record VisitorDto(
        string Ssn,
        string Name,
        DateOnly Birthday,
        Gender Gender,
        string Email,
        AddressDto Address);
}