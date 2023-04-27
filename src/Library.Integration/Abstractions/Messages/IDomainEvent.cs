using MediatR;

namespace Library.Integration.Abstractions.Messages;

public interface IDomainEvent : IMessage, IPublisher { }