using System.Collections.Immutable;
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
                .Entries<IHaveDomainEvents>()
                .Select(entry => entry.Entity)
                .Where(entity => entity.GetDomainEvents().Count > 0)
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
    
    private async Task PublishEntityDomainEventsAsync(IHaveDomainEvents entity, CancellationToken cancellationToken)
    {
        var domainEventsCopy = entity.GetDomainEvents().ToImmutableList();
        
        foreach (var domainEvent in domainEventsCopy)
        {
            var domainEventHandlers = _domainEventHandlerResolver.ResolveHandlerInstances(domainEvent);
            
            // Remove the domain event to prevent recursion if SaveChanges is called within a handler
            entity.GetDomainEvents().Remove(domainEvent);
            
            foreach (var domainEventHandler in domainEventHandlers)
            {
                await ((dynamic)domainEventHandler).HandleAsync((dynamic)domainEvent, cancellationToken);
            }
        }
    }
}
