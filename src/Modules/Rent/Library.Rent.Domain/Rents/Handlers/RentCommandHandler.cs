using Devpack.Notifications.Notifier;
using Library.Rent.Domain.Rents.Commands;
using MediatR;

namespace Library.Rent.Domain.Rents.Handlers
{
    public class RentCommandHandler : IRequestHandler<CreateRentCommand>
    {
        private readonly INotifier _notifier;

        public RentCommandHandler(INotifier notifier)
        {
            _notifier = notifier;
        }

        public Task Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            var rent = new Rent(request);
            var validation = rent.Validate();

            if (validation.IsValid)
            {
                _notifier.NotifyAsync(validation);
                return null!;
            }

            // Criar no banco de dados
            // Save async
            // Notificar envio de comando para notificação 

            return Task.CompletedTask;
        }
    }
}