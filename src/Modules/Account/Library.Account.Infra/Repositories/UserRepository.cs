using Library.Account.Domain.Users;
using Microsoft.Extensions.Logging;

namespace Library.Account.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public Task AddUserAsync(User user)
        {
            _logger.LogInformation("Usuário inserido");
            return Task.CompletedTask;
        }
    }
}