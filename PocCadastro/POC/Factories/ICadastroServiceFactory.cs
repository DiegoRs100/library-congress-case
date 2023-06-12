using POC.Models;
using POC.Service.Cadastro;

namespace POC.Factories
{
    public interface ICadastroServiceFactory
    {
        ICadastroService CriarServicoCadastro(CadastroUsuarioRegras regra);
    }
}
