using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

internal class DeactiveShelfItemHandler : ApplicationShelfHandler<Command.DeactiveShelfItem>
{
    public DeactiveShelfItemHandler(IApplicationService service)
        : base(service) { }
}
