using Library.Integration.Abstractions.Messages;
using Library.Shelf.Application.Services;

using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Abstactions.Handles;

public abstract class ApplicationShelfHandler<TCommand> : IInteractorCommand<TCommand>
    where TCommand : ICommand
{
    private readonly IApplicationService _service;
    private readonly bool _isNew;

    public ApplicationShelfHandler(IApplicationService service, bool isNew = false)
        => (_service, _isNew) = (service, isNew);

    public virtual async Task<IReadOnlyCollection<IDomainEvent>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        ShelfAggregate aggregate;

        if (_isNew)
            aggregate = new();
        else
            aggregate = await _service.RecoverAggregateAsync(request.Id, cancellationToken);

        aggregate.Handle(request);

        return await _service.SaveAggregateAsync(aggregate, _isNew, cancellationToken);
    }
}
