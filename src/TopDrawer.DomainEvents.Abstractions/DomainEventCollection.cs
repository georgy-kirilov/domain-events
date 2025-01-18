using System.Collections;
using System.Collections.Generic;

namespace TopDrawer.DomainEvents.Abstractions
{
    public sealed class DomainEventCollection : IEnumerable<IDomainEvent>
    {
        private readonly HashSet<IDomainEvent> _domainEvents = new HashSet<IDomainEvent>();
        
        public int Count => _domainEvents.Count;
        
        public void Add(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        
        public IEnumerator<IDomainEvent> GetEnumerator()
        {
            return ((IEnumerable<IDomainEvent>)_domainEvents).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        internal void Remove(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    }
}
