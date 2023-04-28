using Library.Api.Controllers.Base;
using Library.Rent.Application.Rents.Services;
using Library.Rent.Domain.Rents.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("rent")]
    public class RentController : MainController
    {
        private readonly IRentAppService _rentAppService;

        public RentController(IRentAppService rentAppService)
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