using ExampleApp.Common.Abstractions;

namespace ExampleApp.Domain.Cards;

public sealed record CardRequestedDomainEvent(Guid CardId) : IDomainEvent;
