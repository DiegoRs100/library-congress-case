using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class ChangeShelfDescriptionHandler : ApplicationShelfHandler<Command.ChangeShelfDescription>
{
    public ChangeShelfDescriptionHandler(IApplicationService service)
        : base(service) { }

    public override Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.ChangeShelfDescription request, CancellationToken cancellationToken)
        => base.Handle(request, cancellationToken);
}
