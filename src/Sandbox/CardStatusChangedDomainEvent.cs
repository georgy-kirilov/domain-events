using TopDrawer.DomainEvents;
using TopDrawer.DomainEvents.Abstractions;

namespace Sandbox;

public class CardStatusChangedDomainEvent : IDomainEvent
{
    public required int CardId { get; init; }
    
    public required string NewStatus { get; init; }
}
