using System.Collections.Generic;

namespace TopDrawer.DomainEvents
{
    public interface IDomainEventResolver
    {
        IEnumerable<object> ResolveHandlers(IDomainEvent domainEvent);
    }
}
