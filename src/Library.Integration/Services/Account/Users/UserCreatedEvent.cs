﻿using Library.Core;

namespace Library.Integration.Services.Account.Users
{
    public record UserCreatedEvent : Event
    {
        public Guid UserId { get; set; }

        public UserCreatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}