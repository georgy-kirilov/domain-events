using Microsoft.Extensions.DependencyInjection;
using TopDrawer.DomainEvents.Abstractions;

namespace TopDrawer.DomainEvents.AspNetCore;

internal sealed class AspNetCoreDomainEventHandlerResolver(
    IServiceProvider serviceProvider,
    DomainEventServiceContainer domainEventServiceContainer) : IDomainEventHandlerResolver
{
    public IEnumerable<object> ResolveHandlerInstances(IDomainEvent domainEvent)
    {
        var handlerTypes = domainEventServiceContainer.GetHandlerTypesForDomainEvent(domainEvent);

        foreach (var handlerType in handlerTypes)
        {
            yield return serviceProvider.GetRequiredService(handlerType);
        }
    }
}
