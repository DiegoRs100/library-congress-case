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
        => await _repository.GetAsync(guid, cancellationToken) ?? new();

    public async Task<IReadOnlyCollection<IDomainEvent>> SaveAggregateAsync<TEntity>(TEntity entity, IReadOnlyCollection<IDomainEvent> events, bool isNew, CancellationToken cancellationToken)
        where TEntity : class
    {
        if (events.Any() is false)
            return events;

        if (isNew)
            await _repository.InsertAsync(entity, cancellationToken);
        else
            await _repository.UpdateAsync(entity, cancellationToken);

        await Task.WhenAll(events.Select(@event => _mediator.Publish(@event, cancellationToken)));

        return events;
    }
}