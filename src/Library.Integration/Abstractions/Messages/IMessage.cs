﻿namespace Library.Integration.Abstractions.Messages;

public interface IMessage
{
    DateTimeOffset Timestamp { get; }
}