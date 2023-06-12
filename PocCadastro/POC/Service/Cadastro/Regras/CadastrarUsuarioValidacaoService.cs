using POC.Models;
using System.ComponentModel.DataAnnotations;

namespace POC.Service.Cadastro.Regras
{
    public class CadastrarUsuarioValidacaoService : 
        IUsuarioCadastroPortalService,
        IUsuarioCadastroChatbotService
    {
        private readonly ICadastroService _cadastroService;

        public CadastrarUsuarioValidacaoService(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public Task Cadastrar(Usuario usuario)
        {
            Console.WriteLine("Validar dados");
            _cadastroService.Cadastrar(usuario);
            return Task.FromResult(0);
        }
    }
}