using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Handles.Commands;

public class CreateShelfHandle : IInteractorCommand<Command.CreateShelf, Guid>
{
    public async Task<Guid> Handle(Command.CreateShelf request, CancellationToken cancellationToken)
    {
        ShelfAggregate aggregate = new();
        aggregate.Handle(request);

        return default;
    }
}
