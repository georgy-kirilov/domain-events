using ExampleApp.Common.IntegrationEvents;
using ExampleApp.Domain.Cards;
using ExampleApp.Domain.Cards.Issuance;
using MassTransit;

namespace ExampleApp.Features.CardIssuanceCompleted;

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
