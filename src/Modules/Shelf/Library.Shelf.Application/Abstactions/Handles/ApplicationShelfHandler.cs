using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Abstactions.Handles;

public abstract class ApplicationShelfHandler<TCommand> : IInteractorCommand<TCommand>
    where TCommand : ICommand
{
    private readonly IApplicationService _service;

    public ApplicationShelfHandler(IApplicationService service)
        => _service = service;

    public async Task<IReadOnlyCollection<IDomainEvent>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var aggregate = await _service.RecoverAggregateAsync(request.ShelfId, cancellationToken);
        aggregate.Handle(request);

        return await _service.SaveAggregateAsync(aggregate, false, cancellationToken);
    }
}
