namespace Library.Account.Domain.Users
{
    public interface IUserRepository
    {
        public Task<User> AddUserAsync(User user);
    }
}