using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class ActivateShelfHandler : ApplicationShelfHandler<Command.ActivateShelf>
{
    public ActivateShelfHandler(IApplicationService service)
        : base(service) { }

    public override Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.ActivateShelf request, CancellationToken cancellationToken)
        => base.Handle(request, cancellationToken);
}
