using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Abstactions.Repositories;
using MediatR;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Handles.Commands;

public class CreateShelfHandle : IInteractorCommand<Command.CreateShelf>
{
    private readonly IShelfRepository _repository;

    public CreateShelfHandle(IShelfRepository repository)
        => _repository = repository;

    public async Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.CreateShelf request, CancellationToken cancellationToken)
    {
        ShelfAggregate aggregate = new();
        aggregate.Handle(request);

        await _repository.InsertAsync(aggregate, cancellationToken);

        return aggregate.Events;
    }
}
