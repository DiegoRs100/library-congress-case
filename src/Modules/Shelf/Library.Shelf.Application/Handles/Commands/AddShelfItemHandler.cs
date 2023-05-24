using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class AddShelfItemHandler : IInteractorCommand<Command.AddShelfItem>
{
    private readonly IApplicationService _service;

    public AddShelfItemHandler(IApplicationService service)
        => _service = service;

    public async Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.AddShelfItem request, CancellationToken cancellationToken)
    {
        var aggregate = await _service.RecoverAggregateAsync(request.ShelfId, cancellationToken);
        aggregate.Handle(request);

        return await _service.SaveAggregateAsync(aggregate, false, cancellationToken);
    }
}
