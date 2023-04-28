using Library.Integration.Abstractions.Messages;
using MediatR;

namespace Library.Shelf.Application.Abstactions.Handles;

public interface IInteractorCommand<in TMessage> : IRequestHandler<TMessage, IReadOnlyCollection<IDomainEvent>>
    where TMessage : ICommand
{
}
