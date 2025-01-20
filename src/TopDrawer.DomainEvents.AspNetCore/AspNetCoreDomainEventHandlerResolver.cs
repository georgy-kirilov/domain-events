using Microsoft.Extensions.DependencyInjection;
using TopDrawer.DomainEvents.Abstractions;

namespace TopDrawer.DomainEvents.AspNetCore;

internal sealed class AspNetCoreDomainEventHandlerResolver(
    IServiceProvider serviceProvider,
    DomainEventServiceContainer domainEventServiceContainer) : IDomainEventHandlerResolver
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly DomainEventServiceContainer _domainEventServiceContainer = domainEventServiceContainer;

    public IEnumerable<object> ResolveHandlerInstances(IDomainEvent domainEvent)
    {
        var handlerTypes = _domainEventServiceContainer.GetHandlerTypesForDomainEvent(domainEvent);

        foreach (var handlerType in handlerTypes)
        {
            yield return _serviceProvider.GetRequiredService(handlerType);
        }
    }
}
