using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using MediatR;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Handles.Commands;

public class CreateShelfHandle : IRequestHandler<Command.CreateShelf, Guid>
{
    public async Task<Guid> Handle(Command.CreateShelf request, CancellationToken cancellationToken)
    {
        ShelfAggregate aggregate = new();
        aggregate.Handle(request);

        return default;
    }
}
