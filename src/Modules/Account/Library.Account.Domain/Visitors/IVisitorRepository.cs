﻿namespace Library.Account.Domain.Visitors
{
    public interface IVisitorRepository
    {
        public Task<Visitor> AddVisitorAsync(Visitor user);
    }
}