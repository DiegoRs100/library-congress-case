using Library.Core.Abstractions.Infra;

namespace Library.Account.Domain.Visitors.Repositories
{
    public interface IVisitorRepository : IRepository
    {
        public Task AddVisitorAsync(Visitor user);
        public Task<bool> HasVisitorBySsnAsync(string ssn);
    }
}