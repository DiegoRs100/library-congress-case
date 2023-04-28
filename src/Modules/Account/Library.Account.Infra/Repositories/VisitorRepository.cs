using Library.Account.Domain.Users;
using Library.Account.Domain.Visitors;
using Library.Account.Domain.Visitors.Repositories;
using Library.Core.Abstractions.Infra;
using Microsoft.Extensions.Logging;

namespace Library.Account.Infra.Repositories
{
    public class VisitorRepository : Repository, IVisitorRepository
    {
        private readonly ILogger<VisitorRepository> _logger;

        public VisitorRepository(ILogger<VisitorRepository> logger)
        {
            _logger = logger;
        }

        public Task AddVisitorAsync(Visitor user)
        {
            _logger.LogInformation("Visitante inserido.");
            return Task.CompletedTask;
        }

        public Task<bool> HasVisitorBySsnAsync(string ssn)
        {
            return Task.FromResult(true);
        }
    }
}