using Library.Core.Infra;

namespace Library.Account.Domain.Visitors.Repositories
{
    public interface IVisitorRepository : IRepository
    {
        public Task<Visitor> AddVisitorAsync(Visitor user);
        public Task<bool> HasVisitorBySsnAsync(string ssn);
    }
}