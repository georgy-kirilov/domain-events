using ExampleApp.Domain.Cards.Issuance;
using TopDrawer.DomainEvents.Abstractions;

namespace ExampleApp.Domain.Cards.Plastics;

public sealed class CardIssuanceCompletedDomainEventHandler(
    ICardRepository cardRepository,
    ICardPlasticRepository cardPlasticRepository) : IDomainEventHandler<CardIssuanceCompletedDomainEvent>
{
    public async Task HandleAsync(CardIssuanceCompletedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var card = await cardRepository.LoadCardById(domainEvent.CardId, cancellationToken);

        if (card.Type.SupportsPlastic())
        {
            var plastic = CardPlastic.Create(card);
            cardPlasticRepository.AddCardPlastic(plastic);
        }
    }
}
