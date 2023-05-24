using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class CreateShelfHandle : ApplicationShelfHandler<Command.CreateShelf>
{

    public CreateShelfHandle(IApplicationService service)
        : base(service, true) { }

    public override Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.CreateShelf request, CancellationToken cancellationToken)
        => base.Handle(request, cancellationToken);
}
