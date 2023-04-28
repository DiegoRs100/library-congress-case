using Library.Rent.Domain.Rents.Aggregates;
using MediatR;

namespace Library.Rent.Domain.Rents.Commands
{
    public record CreateRentCommand : IRequest
    {
        public Guid VisitorId { get; set; }
        public IReadOnlyCollection<RentItem> Itens { get; set; } = default!;
    }
}