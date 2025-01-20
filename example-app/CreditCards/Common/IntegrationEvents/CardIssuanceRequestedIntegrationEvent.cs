using CreditCards.Domain.Cards;

namespace CreditCards.Common.IntegrationEvents;

public sealed record CardIssuanceRequestedIntegrationEvent(
    Guid CardId,
    CardType CardType,
    decimal CreditLimit,
    string CreditContractNumber);
