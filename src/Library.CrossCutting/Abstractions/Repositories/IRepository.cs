namespace Library.Core.Abstractions.Infra
{
    public interface IRepository
    {
        Task CommitAsync();
    }
}