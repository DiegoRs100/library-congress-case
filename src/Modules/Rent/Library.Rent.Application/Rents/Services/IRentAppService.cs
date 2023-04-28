using Library.Rent.Domain.Rents;
using Library.Rent.Domain.Rents.Commands;

namespace Library.Rent.Application.Rents.Services
{
    public interface IRentAppService
    {
        Task Rent(CreateRentCommand command);
        Task GetRentsByUser(CreateRentCommand command);

        Task ReturnRentedItems(CreateRentCommand command);
        Task RenewItemRentals(CreateRentCommand command);

        Task RegisterDelayReturn(CreateRentCommand command);
    }
}