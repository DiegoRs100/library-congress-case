using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Abstactions.Repositories;
using Library.Shelf.Application.Services;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Handles.Commands;

public class CreateShelfHandle : IInteractorCommand<Command.CreateShelf>
{
    private readonly IApplicationService _service;

    public CreateShelfHandle(IApplicationService service)
        => _service = service;

    public async Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.CreateShelf request, CancellationToken cancellationToken)
    {
        ShelfAggregate aggregate = new();
        aggregate.Handle(request);

        return await _service.SaveAggregateAsync(aggregate, true, cancellationToken);
    }
}
