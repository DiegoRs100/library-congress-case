using Library.Integration.Abstractions.Messages;
using MediatR;

namespace Library.Shelf.Application.Abstactions.Handles;

public interface IInteractorCommand<in TMessage, TResult> : IRequestHandler<TMessage, TResult>
    where TMessage : ICommand<TResult>
{
}
