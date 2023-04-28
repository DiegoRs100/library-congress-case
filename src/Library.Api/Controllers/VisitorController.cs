using Library.Account.Application.Visitors.Dto_s;
using Library.Account.Application.Visitors.Services;
using Library.Api.Controllers.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("account/visitor")]
    public class VisitorController : MainController
    {
        //private readonly IVisitorAppService _visitorAppService;

        //public VisitorController(IVisitorAppService visitorAppService)
        //{
        //    _visitorAppService = visitorAppService;
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateVisitorAsync(VisitorDto visitor)
        //{
        //    visitor = await _visitorAppService.CreateVisitorAsync(visitor);
        //    return Ok(visitor);
        //}
    }
}