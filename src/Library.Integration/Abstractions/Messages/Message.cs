using System.Text.Json.Serialization;

namespace Library.Integration.Abstractions.Messages;

public abstract record Message : IMessage
{
	public Message(Guid id)
	{
		Id = id;
	}

	[JsonIgnore]
    public Guid Id { get; }
}
