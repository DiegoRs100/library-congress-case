using Microsoft.AspNetCore.Mvc;
using POC.Models;
using POC.Service;

namespace POC.Controllers
{
    [ApiController]
    [Route("conta")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost(Name = "cadastrar")]
        public async Task<IActionResult> Get(CadastroUsuarioRegras origem)
        {
            await _contaService.CadastrarUsuario(origem, new Usuario()
            {
                Id = Guid.NewGuid()
            });

            return Ok();
        }
    }
}
