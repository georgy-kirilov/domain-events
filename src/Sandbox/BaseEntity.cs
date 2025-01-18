using TopDrawer.DomainEvents;

namespace Sandbox;

public abstract class BaseEntity : IHaveDomainEvents
{
    private readonly DomainEventCollection _domainEvents = [];
    
    public DomainEventCollection GetDomainEvents() => _domainEvents;
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
