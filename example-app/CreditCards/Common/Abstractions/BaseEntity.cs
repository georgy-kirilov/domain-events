namespace CreditCards.Common.Abstractions;

public abstract class BaseEntity : IHaveDomainEvents
{
    private readonly DomainEventCollection _domainEvents = [];
    
    public DomainEventCollection GetDomainEvents() => _domainEvents;
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
