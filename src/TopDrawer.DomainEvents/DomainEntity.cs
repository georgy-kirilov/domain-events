namespace TopDrawer.DomainEvents
{
    public abstract class DomainEntity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;
    
        protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
        internal void ClearDomainEvents() => _domainEvents.Clear();
    }
}
