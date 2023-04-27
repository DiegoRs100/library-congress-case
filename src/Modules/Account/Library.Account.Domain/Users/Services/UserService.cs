using Library.Account.Domain.Visitors;

namespace Library.Account.Domain.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(Visitor visitor)
        {
            var user = new User(visitor);
            var validation = user.Validate();

            if (!validation.IsValid)
            {
                // notificar erros de validação
                return null!;
            }

            await _userRepository.AddUserAsync(user);

            // Savechanges



            return user;
        }
    }
}