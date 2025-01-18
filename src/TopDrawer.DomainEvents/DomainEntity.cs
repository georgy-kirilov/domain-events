using System.Collections.Generic;

namespace TopDrawer.DomainEvents
{
    public abstract class DomainEntity
    {
        private readonly HashSet<IDomainEvent> _domainEvents = new HashSet<IDomainEvent>();
        
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
    
        protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        
        internal void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    }
}
