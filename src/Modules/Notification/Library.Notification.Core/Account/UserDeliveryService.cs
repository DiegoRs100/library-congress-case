using Library.Integration.Services.Account.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Notification.Account
{
    // Considerando que esse projeto tem por objetivo explorar a construção do DDD e não de envio de emails,
    // todos os envios serão representados por um log.
    public class UserDelivery : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<UserDelivery> _logger;

        public UserDelivery(ILogger<UserDelivery> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Email de criação de usuário enviado.");
            return Task.CompletedTask;
        }
    }
}