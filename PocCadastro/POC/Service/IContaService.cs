using POC.Models;

namespace POC.Service
{
    public interface IContaService
    {
        public Task CadastrarUsuario(CadastroUsuarioRegras regra, Usuario usuario);
    }
}