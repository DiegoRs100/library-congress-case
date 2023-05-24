using Library.Integration.Abstractions.Messages;
using Library.Shelf.Application.Abstactions.Repositories;
using MediatR;

using ShelfAggregate = Library.Shelf.Domain.Aggregates.Shelf;

namespace Library.Shelf.Application.Services;

public class ApplicationService : IApplicationService
{
    private readonly IShelfRepository _repository;
    private readonly IMediator _mediator;

    public ApplicationService(IShelfRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<ShelfAggregate> RecoverAggregateAsync(Guid guid, CancellationToken cancellationToken)
        => await _repository.GetAsync(guid, cancellationToken) ?? throw new Exception("Shelf not found");

    public async Task<IReadOnlyCollection<IDomainEvent>> SaveAggregateAsync(ShelfAggregate aggregate, bool isNew, CancellationToken cancellationToken)
    {
        if (aggregate.Events.Any() is false)
            return aggregate.Events;

        if(isNew)
            await _repository.InsertAsync(aggregate, cancellationToken);
        else
            await _repository.UpdateAsync(aggregate, cancellationToken);

        await Task.WhenAll(aggregate.Events.Select(@event => _mediator.Publish(@event, cancellationToken)));
        
        return aggregate.Events;
    }
}