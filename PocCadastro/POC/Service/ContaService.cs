using POC.Factories;
using POC.Models;
using POC.Service.Cadastro;

namespace POC.Service
{
    public class ContaService : IContaService
    {
        private readonly ICadastroServiceFactory _cadastroServiceFactory;

        public ContaService(ICadastroServiceFactory cadastroServiceFactory)
        {
            _cadastroServiceFactory = cadastroServiceFactory;
        }

        public Task CadastrarUsuario(CadastroUsuarioRegras regra, Usuario usuario)
        {
            var cadastroService = _cadastroServiceFactory.CriarServicoCadastro(regra);
            return cadastroService.Cadastrar(usuario);
        }

        public Task ConfirmarCadastro()
        {
            // Código de validação de cadastro
            return Task.CompletedTask;
        }
    }
}
