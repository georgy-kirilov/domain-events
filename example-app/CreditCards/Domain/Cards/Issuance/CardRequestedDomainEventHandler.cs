using CreditCards.Common.IntegrationEvents;
using CreditCards.Common.Services;
using CreditCards.Domain.Credits;

namespace CreditCards.Domain.Cards.Issuance;

public sealed class CardRequestedDomainEventHandler(
    ICurrentUserService currentUserService,
    ICardIssuanceRepository cardIssuanceRepository,
    ICardRepository cardRepository,
    ICreditRepository creditRepository,
    IPublishEndpoint publishEndpoint) : IDomainEventHandler<CardRequestedDomainEvent>
{
    public async Task HandleAsync(CardRequestedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var userId = currentUserService.GetUserId();
        var cardIssuance = CardIssuance.Create(domainEvent.CardId, userId);
        
        cardIssuanceRepository.AddCardIssuance(cardIssuance);
        
        var card = await cardRepository.LoadCardById(domainEvent.CardId, cancellationToken);
        var credit = await creditRepository.LoadCreditById(card.CreditId, cancellationToken);
        
        var integrationEvent = new CardIssuanceRequestedIntegrationEvent(
            card.CardId,
            card.Type,
            credit.Limit,
            credit.ContractNumber);
        
        await publishEndpoint.Publish(integrationEvent, cancellationToken);
    }
}
