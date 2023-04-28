using MediatR;

namespace Library.Integration.Abstractions.Messages;

public interface ICommand<TResult> : IMessage, IRequest<TResult> { }