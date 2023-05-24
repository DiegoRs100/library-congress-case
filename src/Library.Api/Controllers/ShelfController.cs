using Library.Api.Abstractions;
using Library.Integration.Abstractions.Messages;
using Library.Integration.Services.Shelf;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[Route("shelf")]
public class ShelfController : ApplicationController
{
    public ShelfController(IMediator mediator)
        : base(mediator) { }

    [HttpPost]
    public Task<IActionResult> CreateShelfAsync([FromBody] Command.CreateShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteShelfAsync([FromRoute] Command.DeleteShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpPatch]
    [Route("activate/{id}")]
    public Task<IActionResult> ActivateShelfAsync([FromRoute] Command.ActivateShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpPatch]
    [Route("deactivate/{id}")]
    public Task<IActionResult> DeactivateShelfAsync([FromRoute] Command.DeactivateShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);
}
