using System.Collections.Generic;

namespace TopDrawer.DomainEvents.Abstractions
{
    public interface IDomainEventHandlerResolver
    {
        IEnumerable<object> ResolveHandlerInstances(IDomainEvent domainEvent);
    }
}
