using CreditCards.Common.Abstractions;

namespace CreditCards.Domain.Cards;

public sealed record CardRequestedDomainEvent(Guid CardId) : IDomainEvent;
