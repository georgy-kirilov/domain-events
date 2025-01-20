namespace CreditCards.Common.Abstractions;

public interface IDomainEventHandler<in TDomainEvent>
    : TopDrawer.DomainEvents.Abstractions.IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}
