using POC.Models;

namespace POC.Service.Cadastro.Regras
{
    public class CadastrarUsuarioPersistenciaService : 
        IUsuarioCadastroPortalService,
        IUsuarioCadastroChatbotService
    {
        public Task Cadastrar(Usuario usuario)
        {
            Console.WriteLine("Salvo no banco");
            Console.WriteLine("-------------------------");
            return Task.CompletedTask;
        }
    }
}
