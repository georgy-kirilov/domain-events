using ExampleApp.Common.Abstractions;

namespace ExampleApp.Domain.Cards.Issuance;

public sealed record CardIssuanceCompletedDomainEvent(Guid CardId) : IDomainEvent;
