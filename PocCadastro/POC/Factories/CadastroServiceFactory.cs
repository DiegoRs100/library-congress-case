using POC.Models;
using POC.Service.Cadastro;

namespace POC.Factories
{
    public class CadastroServiceFactory : ICadastroServiceFactory
    {
        private readonly IUsuarioCadastroPortalService _portalCadastroService;
        private readonly IUsuarioCadastroChatbotService _chatbotCadastroService;

        public CadastroServiceFactory(IUsuarioCadastroPortalService portalCadastroService,
                                      IUsuarioCadastroChatbotService chatbotCadastroService)
        {
            _portalCadastroService = portalCadastroService;
            _chatbotCadastroService = chatbotCadastroService;
        }

        public ICadastroService CriarServicoCadastro(CadastroUsuarioRegras regra)
        {
            return regra switch
            {
                CadastroUsuarioRegras.Portal => _portalCadastroService,
                CadastroUsuarioRegras.Chatbot => _chatbotCadastroService,
                _ => throw new NotImplementedException()
            };
        }
    }
}
