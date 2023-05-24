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

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteShelfAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.DeleteShelf(id), cancellationToken);

    [HttpPatch]
    [Route("{id:guid}/activate")]
    public Task<IActionResult> ActivateShelfAsync([FromRoute] Command.ActivateShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpPatch]
    [Route("{id:guid}/deactivate")]
    public Task<IActionResult> DeactivateShelfAsync([FromRoute] Command.DeactivateShelf command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpPost]
    [Route("{id:guid}/shelf-item")]
    public Task<IActionResult> AddShelfItemAsync([FromRoute] Command.AddShelfItem command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpDelete]
    [Route("{id:guid}/shelf-item/{id:guid}")]
    public Task<IActionResult> RemoveShelfItemAsync([FromRoute] Command.RemoveShelfItem command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);
}
