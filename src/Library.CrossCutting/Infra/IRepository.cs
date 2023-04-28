namespace Library.Core.Infra
{
    public interface IRepository
    {
        Task CommitAsync();
    }
}