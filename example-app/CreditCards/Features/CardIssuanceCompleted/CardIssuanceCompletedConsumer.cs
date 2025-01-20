using CreditCards.Common.IntegrationEvents;
using CreditCards.Domain.Cards;
using CreditCards.Domain.Cards.Issuance;

namespace CreditCards.Features.CardIssuanceCompleted;

public sealed class CardIssuanceCompletedConsumer(
    ICardRepository cardRepository,
    ICardIssuanceRepository cardIssuanceRepository) : IConsumer<CardIssuanceCompletedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<CardIssuanceCompletedIntegrationEvent> context)
    {
        var card = await cardRepository.LoadCardById(context.Message.CardId, context.CancellationToken);
        
        var issuance = await cardIssuanceRepository.LoadCardIssuanceByCardId(card.CardId, context.CancellationToken);
        
        issuance.Complete(card, context.Message.PanNumber, context.Message.ExpiryDate);
    }
}
