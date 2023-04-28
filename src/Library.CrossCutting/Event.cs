using MediatR;

namespace Library.Core
{
    public abstract record Event : INotification
    { }
}