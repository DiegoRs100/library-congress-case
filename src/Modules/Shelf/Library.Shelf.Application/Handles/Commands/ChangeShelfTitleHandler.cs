using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class ChangeShelfTitleHandler : ApplicationShelfHandler<Command.ChangeShelfTitle>
{
    public ChangeShelfTitleHandler(IApplicationService service) 
        : base(service) { }
}
