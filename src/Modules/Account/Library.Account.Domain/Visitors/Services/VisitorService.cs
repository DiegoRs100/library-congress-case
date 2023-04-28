using Devpack.Notifications.Notifier;
using Library.Account.Domain.Users.Services;
using Library.Account.Domain.Visitors.Repositories;
using Microsoft.Extensions.Logging;

namespace Library.Account.Domain.Visitors.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IUserService _userService;
        private readonly INotifier _notifier;
        private readonly ILogger<VisitorService> _logger;

        public VisitorService(IVisitorRepository visitorRepository,
                              IUserService userService,
                              INotifier notifier,
                              ILogger<VisitorService> logger)
        {
            _visitorRepository = visitorRepository;
            _userService = userService;
            _notifier = notifier;
            _logger = logger;
        }

        public async Task<Visitor> CreateVisitorAsync(Visitor visitor)
        {
            var validation = visitor.Validate();

            if (!validation.IsValid) 
            {
                await _notifier.NotifyAsync(validation);
                return null!;
            }

            if (await _visitorRepository.HasVisitorBySsnAsync(visitor.Ssn))
            {
                await _notifier.NotifyAsync("There is already a registered visitor with this SSN.");
                return null!;
            }

            await _visitorRepository.AddVisitorAsync(visitor);
            await _visitorRepository.CommitAsync();

            var user = await _userService.CreateUserAsync(visitor);

            if (user == null)
                _logger.LogError("Could not create visitor equivalent userId : {id}", visitor.Id);

            return visitor;
        }
    }
}