using System.Collections.Generic;

namespace TopDrawer.DomainEvents.Abstractions
{
    public interface IDomainEventHandlerInstanceResolver
    {
        IEnumerable<object> ResolveHandlerInstances(IDomainEvent domainEvent);
    }
}
