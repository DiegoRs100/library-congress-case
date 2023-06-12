using POC.Models;

namespace POC.Service.Cadastro.Regras
{
    public class CadastrarUsuarioEnriquecimentoService : 
        IUsuarioCadastroPortalService
    {
        private readonly ICadastroService _cadastroService;

        public CadastrarUsuarioEnriquecimentoService(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public Task Cadastrar(Usuario usuario)
        {
            Console.WriteLine("Enriquecer usuário");
            _cadastroService.Cadastrar(usuario);
            return Task.CompletedTask;
        }
    }
}
