using Library.Integration.Abstractions.Messages;
using Library.Integration.DataTransferObjects;

namespace Library.Integration.Services.Shelf;

public static class Command
{
    public record CreateShelf(Guid ShelfId, string Title, string Description, Dto.Location Location) : Message, ICommand;

    public record DeleteShelf(Guid ShelfId) : Message, ICommand;
}