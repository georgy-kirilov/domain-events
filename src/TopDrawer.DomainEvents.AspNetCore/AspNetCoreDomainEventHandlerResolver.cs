using Microsoft.Extensions.DependencyInjection;
using TopDrawer.DomainEvents.Abstractions;

namespace TopDrawer.DomainEvents.AspNetCore;

internal sealed class AspNetCoreDomainEventHandlerResolver(
    IServiceProvider serviceProvider,
    DomainEventContainer domainEventContainer) : IDomainEventHandlerResolver
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly DomainEventContainer _domainEventContainer = domainEventContainer;

    public IEnumerable<object> ResolveHandlerInstances(IDomainEvent domainEvent)
    {
        var handlerTypes = _domainEventContainer.GetHandlerTypesForDomainEvent(domainEvent);

        foreach (var handlerType in handlerTypes)
        {
            yield return _serviceProvider.GetRequiredService(handlerType);
        }
    }
}
