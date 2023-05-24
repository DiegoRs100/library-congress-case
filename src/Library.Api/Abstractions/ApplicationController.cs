using Library.Integration.Abstractions.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json;

namespace Library.Api.Abstractions;

[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    protected ApplicationController(IMediator mediator)
        => _mediator = mediator;

    protected async Task<IActionResult> SendCommandAsync(ICommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return result.Any() 
            ? Ok(JsonSerializer.Serialize(result as IEnumerable, new JsonSerializerOptions
            {
                WriteIndented = true,
            })) 
            : BadRequest();
    }
}