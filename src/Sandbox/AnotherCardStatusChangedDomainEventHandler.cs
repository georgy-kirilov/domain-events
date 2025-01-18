using TopDrawer.DomainEvents;

namespace Sandbox;

public class AnotherCardStatusChangedDomainEventHandler(AppDbContext db) : IDomainEventHandler<CardStatusChangedDomainEvent>
{
    public async Task HandleAsync(CardStatusChangedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        Console.WriteLine("Another card status changed too...");
    }
}
