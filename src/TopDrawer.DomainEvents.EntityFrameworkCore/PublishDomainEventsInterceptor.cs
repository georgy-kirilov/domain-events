using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TopDrawer.DomainEvents.EntityFrameworkCore;

public sealed class PublishDomainEventsInterceptor(IDomainEventHandlerResolver domainEventHandlerResolver)
    : SaveChangesInterceptor
{
    private readonly IDomainEventHandlerResolver _domainEventHandlerResolver = domainEventHandlerResolver;

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        if (eventData.Context is not null)
        {
            await PublishDomainEventsAsync(eventData.Context, cancellationToken);
        }
        
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEventsAsync(DbContext context, CancellationToken cancellationToken)
    {
        while (true)
        {
            var entities = context.ChangeTracker
                .Entries<DomainEntity>()
                .Select(entry => entry.Entity)
                .Where(entity => entity.DomainEvents.Count > 0)
                .ToList();
            
            if (entities.Count == 0)
            {
                break;
            }
            
            foreach (var entity in entities)
            {
                await PublishEntityDomainEventsAsync(entity, cancellationToken);
            }
        }
    }
    
    private async Task PublishEntityDomainEventsAsync(DomainEntity domainEntity, CancellationToken cancellationToken)
    {
        var domainEvents = domainEntity.DomainEvents.ToList();
        
        foreach (var domainEvent in domainEvents)
        {
            var domainEventHandlers = _domainEventHandlerResolver.ResolveHandlerInstances(domainEvent);

            domainEntity.RemoveDomainEvent(domainEvent);
            
            foreach (var domainEventHandler in domainEventHandlers)
            {
                await ((dynamic)domainEventHandler).HandleAsync((dynamic)domainEvent, cancellationToken);
            }
        }
    }
}
