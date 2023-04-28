using Library.Integration.Abstractions.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Abstractions;

[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    protected ApplicationController(IMediator mediator)
        => _mediator = mediator;

    protected async Task<IActionResult> SendCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}