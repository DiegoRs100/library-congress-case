using Library.Account.Domain.Users.Services;

namespace Library.Account.Domain.Visitors.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IUserService _userService;

        public VisitorService(IVisitorRepository visitorRepository,
                              IUserService userService)
        {
            _visitorRepository = visitorRepository;
            _userService = userService;
        }

        public async Task<Visitor> CreateVisitorAsync(Visitor visitor)
        {
            var validation = visitor.Validate();

            if (!validation.IsValid) 
            {
                // notificar erros
                return null!;
            }

            // Valida se ja existe outro consumidor com o mesmo CPF

            await _visitorRepository.AddVisitorAsync(visitor);
            var user = await _userService.CreateUserAsync(visitor);

            if (user == null)
                return null!;

            // Savechanges

            return visitor;
        }
    }
}