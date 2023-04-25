namespace Library.Account.Domain.Visitors.Services
{
    public interface IVisitorService
    {
        public Task<Visitor> CreateVisitorAsync(Visitor visitor);
    }
}