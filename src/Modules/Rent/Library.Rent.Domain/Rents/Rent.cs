using Library.Core;
using Library.Rent.Domain.Books;
using Library.Rent.Domain.Rents.Commands;

namespace Library.Rent.Domain.Rents
{
    public class Rent : Entity, IAggregateRoot
    {
        public Guid VisitorId { get; set; }
        public IReadOnlyCollection<Book> Itens { get; set; }

        public Rent(CreateRentCommand command)
        {
            VisitorId = command.VisitorId;
            Itens = command.Itens;
        }

        // TODO: Criar validation
    }
}