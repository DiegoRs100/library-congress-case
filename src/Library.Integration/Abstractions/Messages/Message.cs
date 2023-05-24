namespace Library.Integration.Abstractions.Messages;

public abstract record Message : IMessage
{
	public Message(Guid id)
	{
		Id = id;
	}

    public Guid Id { get; }
}
