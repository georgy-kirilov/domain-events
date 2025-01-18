using Microsoft.EntityFrameworkCore;
using TopDrawer.DomainEvents;
using TopDrawer.DomainEvents.Abstractions;

namespace Sandbox;

public class CardStatusChangedDomainEventHandler(AppDbContext db) : IDomainEventHandler<CardStatusChangedDomainEvent>
{
    public async Task HandleAsync(CardStatusChangedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var card = await db.Cards.SingleAsync(c => c.Id == domainEvent.CardId, cancellationToken);
        var plastic = new Plastic
        {
            Card = card,
        };
        await db.Plastics.AddAsync(plastic, cancellationToken);
        Console.WriteLine($"Card status changed to '{card.Status}' for card {domainEvent.CardId}.");
    }
}
