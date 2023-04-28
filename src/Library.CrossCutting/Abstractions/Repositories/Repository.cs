namespace Library.Core.Abstractions.Infra
{
    public abstract class Repository : IRepository
    {
        public Task CommitAsync()
        {
            return Task.CompletedTask;
        }
    }
}