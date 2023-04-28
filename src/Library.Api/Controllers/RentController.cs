using Library.Api.Abstractions;
using Library.Rent.Application.Rents.Services;
using Library.Rent.Domain.Rents.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("rent")]
    public class RentController : ApplicationController
    {
        private readonly IRentAppService _rentAppService;

        public RentController(IRentAppService rentAppService, IMediator mediator) : base(mediator)
        {
            _rentAppService = rentAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentAsync(CreateRentCommand command)
        {
            await _rentAppService.RentAsync(command);
            return Ok();
        }
    }
}