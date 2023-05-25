using Library.Integration.Abstractions.Messages;
using Library.Shelf.Application.Services;
using Library.Shelf.Domain.Entities.ShelfItems;
using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Abstactions.Handles;

public abstract class ApplicationShelfHandler<TCommand> : IInteractorCommand<TCommand>
    where TCommand : ICommand
{
    private readonly IApplicationService _service;

    public ApplicationShelfHandler(IApplicationService service)
        => (_service) = (service);

    public virtual async Task<IReadOnlyCollection<IDomainEvent>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var aggregate = await _service.RecoverAggregateAsync(request.Id, cancellationToken);
        aggregate.Handle(request);

        if (aggregate.EntityModified == typeof(ShelfItem))
            return await _service.SaveAggregateAsync(aggregate.Items.First(prop => prop.IsModified), aggregate.Events, aggregate.IsNewRegister, cancellationToken);
        else
            return await _service.SaveAggregateAsync(aggregate, aggregate.Events, aggregate.IsNewRegister, cancellationToken);
    }
}
