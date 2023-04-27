using Devpack.Notifications.Notifier;
using Library.Account.Domain.Users.Services;

namespace Library.Account.Domain.Visitors.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IUserService _userService;
        private readonly INotifier _notifier;

        public VisitorService(IVisitorRepository visitorRepository,
                              IUserService userService,
                              INotifier notifier)
        {
            _visitorRepository = visitorRepository;
            _userService = userService;
            _notifier = notifier;
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
            var user = await _userService.CreateUserAsync(visitor);

            if (user == null)
                return null!;

            //TODO: Savechanges

            return visitor;
        }
    }
}