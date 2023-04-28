using MediatR;
using Microsoft.Extensions.Logging;
using static Library.Integration.Services.Account.Users.UserDomainEvents;

namespace Library.Notification.Account
{
    // Considerando que esse projeto tem por objetivo explorar a construção do DDD e não de envio de emails,
    // todos os envios serão representados por um log.
    public class UserDelivery : INotificationHandler<UserCreated>
    {
        private readonly ILogger<UserDelivery> _logger;

        public UserDelivery(ILogger<UserDelivery> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreated request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Email de criação de usuário enviado.");
            return Task.CompletedTask;
        }
    }
}