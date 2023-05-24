using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class DeactivateShelfHandler : IInteractorCommand<Command.DeactivateShelf>
{
    private readonly IApplicationService _service;

    public DeactivateShelfHandler(IApplicationService service)
        => _service = service;

    public async Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.DeactivateShelf request, CancellationToken cancellationToken)
    {
        var aggregate = await _service.RecoverAggregateAsync(request.Id, cancellationToken);
        aggregate.Handle(request);

        return await _service.SaveAggregateAsync(aggregate, false, cancellationToken);
    }
}
