using CreditCards.Common.Abstractions;

namespace CreditCards.Domain.Cards.Issuance;

public sealed record CardIssuanceCompletedDomainEvent(Guid CardId) : IDomainEvent;
