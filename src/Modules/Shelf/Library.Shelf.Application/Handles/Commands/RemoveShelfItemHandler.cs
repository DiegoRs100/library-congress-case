﻿using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using Library.Shelf.Application.Abstactions.Handles;
using Library.Shelf.Application.Services;

namespace Library.Shelf.Application.Handles.Commands;

public class RemoveShelfItemHandler : IInteractorCommand<Command.RemoveShelfItem>
{
    private readonly IApplicationService _service;

    public RemoveShelfItemHandler(IApplicationService service)
        => _service = service;

    public async Task<IReadOnlyCollection<IDomainEvent>> Handle(Command.RemoveShelfItem request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
