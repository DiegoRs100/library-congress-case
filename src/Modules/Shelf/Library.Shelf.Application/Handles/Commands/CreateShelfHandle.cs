using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using MediatR;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Handles.Commands;

public class CreateShelfHandle : IInteractorCommand<Command.CreateShelf>
{
    public Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.CreateShelf request, CancellationToken cancellationToken)
    {
        ShelfAggregate aggregate = new();
        aggregate.Handle(request);

        return Task.FromResult(aggregate.Events);
    }
}
