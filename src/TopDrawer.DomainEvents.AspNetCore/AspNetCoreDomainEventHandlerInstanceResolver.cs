using Microsoft.Extensions.DependencyInjection;
using TopDrawer.DomainEvents.Abstractions;

namespace TopDrawer.DomainEvents.AspNetCore;

internal sealed class AspNetCoreDomainEventHandlerInstanceResolver(
    IServiceProvider serviceProvider,
    DomainEventServiceContainer domainEventServiceContainer) : IDomainEventHandlerInstanceResolver
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
