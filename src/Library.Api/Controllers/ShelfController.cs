﻿using Library.Api.Abstractions;
using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;
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

    [HttpDelete("{shelfId:guid}")]
    public Task<IActionResult> DeleteShelfAsync([FromRoute] Guid shelfId, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.DeleteShelf(shelfId), cancellationToken);

    [HttpPatch]
    [Route("{shelfId:guid}/activate")]
    public Task<IActionResult> ActivateShelfAsync([FromRoute] Guid shelfId, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.ActivateShelf(shelfId), cancellationToken);

    [HttpPatch]
    [Route("{shelfId:guid}/deactivate")]
    public Task<IActionResult> DeactivateShelfAsync([FromRoute] Guid shelfId, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.DeactivateShelf(shelfId), cancellationToken);

    [HttpPost]
    [Route("shelf-item")]
    public Task<IActionResult> AddShelfItemAsync([FromBody] Command.AddShelfItem command, CancellationToken cancellationToken)
        => SendCommandAsync(command, cancellationToken);

    [HttpPatch]
    [Route("{shelfId:guid}/shelf-item/{shelfItemId:guid}/activate")]
    public Task<IActionResult> ActivateShelfItemAsync([FromRoute] Guid shelfId, [FromRoute] Guid shelfItemId, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.ActiveShelfItem(shelfId, shelfItemId), cancellationToken);

    [HttpPatch]
    [Route("{shelfId:guid}/shelf-item/{shelfItemId:guid}/deactivate")]
    public Task<IActionResult> DeactivateShelfItemAsync([FromRoute] Guid shelfId, [FromRoute] Guid shelfItemId, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.DeactiveShelfItem(shelfId, shelfItemId), cancellationToken);

    [HttpPut]
    [Route("{shelfId:guid}/location")]
    public Task<IActionResult> ChangeShelfLocationAsync([FromRoute] Guid shelfId, [FromBody] Dto.Location location, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.ChangeShelfLocation(shelfId, location), cancellationToken);

    [HttpPatch]
    [Route("{shelfId:guid}/title")]
    public Task<IActionResult> ChangeShelfTitleAsync([FromRoute] Guid shelfId, [FromQuery] string title, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.ChangeShelfTitle(shelfId, title), cancellationToken);

    [HttpPatch]
    [Route("{shelfId:guid}/description")]
    public Task<IActionResult> ChangeShelfDescriptionAsync([FromRoute] Guid shelfId, [FromQuery] string description, CancellationToken cancellationToken)
        => SendCommandAsync(new Command.ChangeShelfDescription(shelfId, description), cancellationToken);
}
