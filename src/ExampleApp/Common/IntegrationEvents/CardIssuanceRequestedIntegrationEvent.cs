using ExampleApp.Domain.Cards;

namespace ExampleApp.Common.IntegrationEvents;

public sealed record CardIssuanceRequestedIntegrationEvent(
    Guid CardId,
    CardType CardType,
    decimal CreditLimit,
    string CreditContractNumber);
