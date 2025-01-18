using TopDrawer.DomainEvents;

namespace Sandbox;

public class AnotherCardStatusChangedDomainEventHandler : IDomainEventHandler<CardStatusChangedDomainEvent>
{
    public Task HandleAsync(CardStatusChangedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        Console.WriteLine("Another card status changed too...");
        return Task.CompletedTask;
    }
}
