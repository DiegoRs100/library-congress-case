using Library.Account.Application.Visitors.Dto_s;
using Library.Account.Application.Visitors.Services;
using Library.Api.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("account/visitor")]
    public class VisitorController : ApplicationController
    {
        private readonly IVisitorAppService _visitorAppService;

        public VisitorController(IVisitorAppService visitorAppService, IMediator mediator) : base(mediator)
        {
            _visitorAppService = visitorAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitorAsync(VisitorDto visitor)
        {
            visitor = await _visitorAppService.CreateVisitorAsync(visitor);
            return Ok(visitor);
        }
    }
}