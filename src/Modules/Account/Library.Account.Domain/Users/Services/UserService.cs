using Library.Account.Domain.Visitors;
using Library.Core.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Account.Domain.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMediator _mediator;

        public UserService(IUserRepository userRepository,
                           ILogger<UserService> logger,
                           IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<User> CreateUserAsync(Visitor visitor)
        {
            var user = new User(visitor);

            if (!user.Validate().IsValid)
            {
                _logger.LogError("Could not create visitor equivalent userId : {id}", visitor.Id);
                return null!;
            }

            await _userRepository.AddUserAsync(user);
            await _userRepository.CommitAsync();

            await _mediator.PublishDomainEvents(user.GetDomainEvents());

            return user;
        }
    }
}