using Library.Core.Abstractions.Infra;

namespace Library.Account.Domain.Users
{
    public interface IUserRepository : IRepository
    {
        public Task AddUserAsync(User user);
    }
}