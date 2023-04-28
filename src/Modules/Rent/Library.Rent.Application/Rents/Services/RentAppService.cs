using Library.Rent.Domain.Rents.Commands;

namespace Library.Rent.Application.Rents.Services
{
    public class RentAppService : IRentAppService
    {
        public Task GetRentsByUser(CreateRentCommand command)
        {
            throw new NotImplementedException();
        }

        public Task RegisterDelayReturn(CreateRentCommand command)
        {
            throw new NotImplementedException();
        }

        public Task RenewItemRentals(CreateRentCommand command)
        {
            throw new NotImplementedException();
        }

        public Task RentAsync(CreateRentCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ReturnRentedItems(CreateRentCommand command)
        {
            throw new NotImplementedException();
        }
    }
}