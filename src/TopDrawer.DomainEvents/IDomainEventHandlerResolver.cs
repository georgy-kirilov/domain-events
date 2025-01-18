using System.Collections.Generic;

namespace TopDrawer.DomainEvents
{
    public interface IDomainEventHandlerResolver
    {
        IEnumerable<object> ResolveHandlerInstances(IDomainEvent domainEvent);
    }
}
