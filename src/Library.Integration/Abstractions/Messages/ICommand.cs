using MediatR;

namespace Library.Integration.Abstractions.Messages;

public interface ICommand : IMessage, IRequest { }