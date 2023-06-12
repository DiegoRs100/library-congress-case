using POC.Models;

namespace POC.Service.Cadastro
{
    public interface ICadastroService
    {
        public Task Cadastrar(Usuario usuario);
    }
}
