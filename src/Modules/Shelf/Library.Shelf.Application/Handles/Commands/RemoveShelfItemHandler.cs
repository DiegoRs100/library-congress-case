using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class RemoveShelfItemHandler : ApplicationShelfHandler<Command.RemoveShelfItem>
{
    public RemoveShelfItemHandler(IApplicationService service)
        : base(service) { }

    public override Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.RemoveShelfItem request, CancellationToken cancellationToken)
        => base.Handle(request, cancellationToken);
}
