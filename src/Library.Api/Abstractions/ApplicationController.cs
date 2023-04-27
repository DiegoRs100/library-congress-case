using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace Library.Api.Abstractions;

[ApiController, Route("api/v{version:apiVersion}/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    protected ApplicationController(IMediator mediator)
        => _mediator = mediator;

    protected async Task<IActionResult> SendCommandAsync(ICommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Accepted();
    }
}
