using Library.Account.Domain.Visitors;

namespace Library.Account.Domain.Users.Services
{
    public interface IUserService
    { 
        public Task<User> CreateUserAsync(Visitor visitor);
    }
}