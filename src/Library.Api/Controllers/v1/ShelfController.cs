using Library.Api.Abstractions;
using Library.Integration.Services.Shelf;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers.v1;

public class ShelfController : ApplicationController
{
    protected ShelfController(IMediator mediator) 
        : base(mediator) { }

    [HttpPost]
    public Task<IActionResult> CreateShelfAsync([FromBody] Command.CreateShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);
}
