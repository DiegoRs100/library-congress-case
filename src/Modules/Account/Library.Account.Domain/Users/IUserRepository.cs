namespace Library.Account.Domain.Users
{
    public interface IUserRepository
    {
        public Task AddUserAsync(User user);
    }
}