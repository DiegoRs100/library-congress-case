namespace Library.Integration.Abstractions.Messages;

public abstract record Message : IMessage
{
    public Guid Id { get; init; }
}
